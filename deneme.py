import numpy as np
import pandas as pd
import random
from holoviews import opts, dim
import holoviews as hv
import panel as pn
from holoviews.streams import Stream
import matplotlib.pyplot as plt
hv.extension('bokeh', logo=False)  



#collapse-hide
class PSO:
    """
    An implementation of Particle Swarm Optimisation, pioneered by Kennedy, Eberhart and Shi.
    
    
    The swarm consists of Particles with 2 fixed length vectors; velocity and position.
    Position is initialised with a uniform distribution between 0 and 1. Velocity is initialised with zeros.
    Each particle has a given number of informants which are randomly chosen at each iteration.
    
    Attributes
    ----------
    swarm_size : int
        The size of the swarm
    vector_length : int
        The dimensions of the problem, should be the same used when creating the problem object 
    num_informants: int
        The number of informants used for social component in particle velocity update 

    Public Methods
    -------
    improve(follow_current, follow_personal_best, follow_social_best, follow_global_best, scale_update_step)
        Update each particle in the swarm and updates the global fitness
    update_swarm(follow_current, follow_personal_best, follow_social_best, follow_global_best, scale_update_step)
        Updates each particle, randomly choosing informants for each particle's update.
    update_global_fittest()
        Updates the `globale_fittest` variable to be the current fittest Particle in the swarm.
    """
    def __init__(self, problem, swarm_size, vector_length, num_informants=2):
        self.swarm_size = swarm_size
        self.num_informants = num_informants
        self.problem = problem
        self.swarm = [Particle(self.problem, np.zeros(vector_length), np.random.rand(vector_length), i)
                      for i, x in enumerate(range(swarm_size))]
        self.global_fittest = np.random.choice(self.swarm, 1)[0]
    
    def update_swarm(self, follow_current, follow_personal_best, follow_social_best, follow_global_best, scale_update_step):
        """Update each particle in the swarm"""
        for particle in self.swarm:
            informants = np.random.choice(self.swarm, self.num_informants)
            if particle not in informants:
                np.append(informants, particle)
            fittest_informant = find_current_best(informants, self.problem)
            particle.update(fittest_informant, 
                            self.global_fittest, 
                            follow_current, 
                            follow_personal_best, 
                            follow_social_best, 
                            follow_global_best, 
                            scale_update_step)
    
    def update_global_fittest(self):
        fittest = find_current_best(self.swarm, self.problem)
        global_fittest_fitness = self.global_fittest.assess_fitness()
        if (fittest.assess_fitness() < global_fittest_fitness):
            self.global_fittest = fittest
    
    def improve(self, follow_current, follow_personal_best, follow_social_best, follow_global_best, scale_update_step):
        """Improves the population for one iteration."""
        self.update_swarm(follow_current, follow_personal_best, follow_social_best, follow_global_best, scale_update_step)
        self.update_global_fittest()
        
size = 25
vector_length = 2
num_informants = 2
pso = PSO(problem, size, vector_length)

def reset_event(event):
    global default_current
    global default_personal_best
    global default_social_best
    global default_global_best
    global default_scale_update_step
    global default_pop_size 
    global default_time
    global default_num_informants
    follow_current_slider.value, follow_personal_best_slider.value = default_current, default_personal_best
    follow_social_best_slider.value, follow_global_best_slider.value = default_social_best, default_global_best
    scale_update_step_slider.value, population_size_slider.value = default_scale_update_step, default_pop_size
    time_slider.value, num_informants_slider.value = default_time, default_num_informants
reset_params_button.on_click(reset_event)


#collapse-show
def tap_event(x,y):
    global target_x
    global target_y
    if x is not None:
        target_x, target_y = x,y
    return hv.Points((x,y,1), label='Target').opts(color='r', marker='^', size=15)



#collapse-show
def update():
    pso.improve(follow_current_slider.value, follow_personal_best_slider.value, 
               follow_social_best_slider.value, follow_global_best_slider.value, 
                scale_update_step_slider.value)
    vect_data = get_vectorfield_data(pso.swarm)
    vectorfield = hv.VectorField(vect_data, vdims=['Angle', 'Magnitude', 'Index'])
    particles = [np.array([vect_data[0], vect_data[1], vect_data[4]]) for i, particle in enumerate(swarm)]
    scatter = hv.Points(particles, vdims=['Index'], group='Particles')
    fittest = hv.Points((pso.global_fittest.fittest_position[0], pso.global_fittest.fittest_position[1],1), label='Current Fittest')
    layout = vectorfield * scatter * fittest 
    layout.opts(
        opts.Points(color='b', fill_alpha=0.1, line_width=1, size=10),
        opts.VectorField(color='Index', cmap='tab20c', magnitude=dim('Magnitude').norm()*10, pivot='tail'),
        opts.Points('Particles', color='Index', cmap='tab20c', size=5, xlim=(0,1), ylim=(0,1))
    )
    return layout



def b(event): 
    global pso
    size = population_size_slider.value
    vector_length = 2
    num_informants = num_informants_slider.value
    pso_fitnesses = []
    pso = PSO(problem, size, vector_length, num_informants)
    particles.periodic(0.005, timeout=time_slider.value) 




#collapse-show
def new_pop_event(event):
    global pso
    size = population_size_slider.value
    num_informants = num_informants_slider.value
    pso = PSO(problem, size, vector_length=2, num_informants=num_informants)
    hv.streams.Stream.trigger(particles.streams)





def next_gen_event(event):
    hv.streams.Stream.trigger(particles.streams)


default_pop_size = 25
default_time = 3
default_num_informants = 6
population_size_slider = pn.widgets.IntSlider(name='Population Size', start=10, end=50, value=default_pop_size)
time_slider = pn.widgets.IntSlider(name='Time Evolving (s)', start=0, end=15, value=default_time)
num_informants_slider = pn.widgets.IntSlider(name='Number of Informants', start=0, end=20, value=default_num_informants)

default_current = 0.7
default_personal_best = 2.0
default_social_best = 0.9
default_global_best = 0.0
default_scale_update_step = 0.7
follow_current_slider = pn.widgets.FloatSlider(name='Follow Current', start=0.0, end=5, value=default_current)
follow_personal_best_slider = pn.widgets.FloatSlider(name='Follow Personal Best', start=0, end=5, value=default_personal_best)
follow_social_best_slider = pn.widgets.FloatSlider(name='Follow Social Best', start=0.0, end=5, value=default_social_best)
follow_global_best_slider = pn.widgets.FloatSlider(name='Follow Global Best', start=0.0, end=1, value=default_global_best)
scale_update_step_slider = pn.widgets.FloatSlider(name='Scale Update Step', start=0.0, end=1, value=0.7)

reset_params_button = pn.widgets.Button(name='Reset Parameters', width=50)
target_x, target_y = 0.5, 0.5
tap_stream = hv.streams.SingleTap(transient=True, x=target_x, y=target_y)
target_tap = hv.DynamicMap(tap_event, streams=[tap_stream])

particles = hv.DynamicMap(update, streams=[Stream.define('Next')()])

run_button = pn.widgets.Button(name='\u25b6 Begin Improving', width=50)   
run_button.on_click(b)
new_pop_button = pn.widgets.Button(name='New Population', width=50)
new_pop_button.on_click(new_pop_event)
next_generation_button = pn.widgets.Button(name='Next Generation', width=50)
next_generation_button.on_click(next_gen_event)


#collapse-show
instructions = pn.pane.Markdown('''
# Particle Swarm Optimisation Dashboard 
## Instructions: 
1. **Click on the plot to place the target.** 
2. Click '\u25b6 Begin Improving' button to begin improving for the time on the Time Evolving slider. 
3. Experiment with the sliders 
''')
dashboard = pn.Column(instructions, 
                      pn.Row((particles*target_tap).opts(width=600, height=600), 
                             pn.Column(
                                 pn.Row(run_button, pn.Spacer(width=50), new_pop_button), 
                                 next_generation_button, 
                                 time_slider, 
                                 num_informants_slider,
                                 population_size_slider,
                                 follow_current_slider, 
                                 follow_personal_best_slider, 
                                 follow_social_best_slider, 
                                 follow_global_best_slider,
                                 scale_update_step_slider,
                                 reset_params_button)))
dashboard
