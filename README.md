# Tech_Market_WebMVC7


							
					Ctnkaya TechMarket ASP.NET Core MVC (.NET 7) - Yiğit Çetinkaya - 201817017

PROJE ÖZET
Bu proje, bir teknoloji mağazası konsepti için geliştirilen bir web uygulamasıdır. Amacı, kullanıcılara teknoloji ürünlerini sergilemek, alışveriş yapma imkanı sunmak ve veritabanı üzerinde temel işlemleri gerçekleştirmektir.

Proje, ASP.NET Core MVC framework'ünü kullanarak geliştirilmiştir ve .NET 7 sürümüne dayanmaktadır. Bu sayede modern ve verimli bir web uygulaması elde edilmiştir. MVC mimarisi ve RAZOR View yapısı kullanılarak, uygulama mantığı, kullanıcı arayüzü ve veritabanı işlemleri kolayca ayrıştırılmıştır.

Veritabanı işlemleri için Entity Framework Core 7 kullanılmıştır. Bu ORM aracı, .NET platformunda veri tabanı erişimi için kullanılan etkili bir araçtır. Uygulama, veritabanı ile etkileşim kurarak ürünleri listeleme, ekleme, silme ve güncelleme gibi temel işlemleri gerçekleştirebilmektedir.

Uygulama, kullanıcılara ürünleri kategorilere göre görüntüleme, ürün detaylarına erişme, sepete ekleme ve satın alma gibi temel işlevleri sunmaktadır. Ayrıca, müşterilerin hesap oluşturma ve giriş yapma özellikleri bulunmaktadır. Yönetici kullanıcıları ise ürün yönetimi, stok güncellemeleri ve siparişleri görüntüleme gibi ek işlevlere sahiptir.

Kullanıcı arayüzü ve interaktif özellikler, Bootstrap ve jQuery teknolojileri kullanılarak geliştirilmiştir. Bu sayede, kullanıcı deneyimi iyileştirilmiş ve etkileşimli bir kullanıcı arayüzü sağlanmıştır.

Proje, GİT kullanılarak adımlar halinde commitlenmiştir. Bu şekilde yapılan değişikliklerin takibi ve proje yönetimi kolaylaştırılmıştır.

Projeye ait görseller .zip içerisinde ve GitHub Repo'sunda belirtilmiştir.

NOT: Projeye ait bütün yapılar başlıklar altında sunulmaktadır.
NOT2: DB Backup dosyası klasör içerisinde yer almaktadır.
NOT3: Proje isterlerinde istenilen bütün yapılar proje içerisine entegre edilerek aktif bir şekilde kullanılmıştır.
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


										  -Uygulama Kullanımı-

Ctnkaya TechMarket:
Müşteriye güncel ürünleri aktararak faydalanmasını sağlayan bir web arayüzüdür.

Burada 3 seçenek sunulur:(Arttırılabilir)
=>Desktop
=>Laptop
=>Gaming Laptop

İsteğe bağlı olarak bu 3 ürün yelpazesinden ürünler tercih edilebilmektedir.

AnaEkran doğrultusunda ürünleri görüntüleyebileceğimiz ve aynı zamanda bunları sepetimize alarak ekleyebileceğimiz bir alan bulunmakta.

Eğer giriş yapılmadan ürün eklenmeye çalışırsa Login sayfasına bir yönlendirme gerçekleştirilir.(Kullanıcı kayıtlı değilse, kayıt olması gerekmektedir.)

Kullanıcı giriş yaptığı taktirde istediği üründen istediği adet kadar alabilmekte,
ve ürünlerini seçerken kelime veya combobox üzerinden seçim yaparak filtreleyebilmektedir.

Bu sayede kullanıcı istediği ürüne kolayca ulaşabilmektedir.

Sepete eklediği ürünleri sağ üst tarafta ürün adedini dinamik bir yapıda görüntüleyebilmekte,kolayca yönetebilmekte, 
arttırma ve azaltma işlemlerini veya kaldırma işlerini gerçekleştirebilmektedir.

Sipariş verdiği ürünlere kullanıcı panelinden rahatlıkla ulaşabilmektedir.


Kullanıcı isterse Sağ üstte yer alan mail adresine tıklayabilir ve buradan Manage your Account sayfasına erişebilir bu sayede bilgilerini değiştirebilir,
Kişisel verilerine ulaşabilir, bu kişisel verileri .json olarak kayıt edebilir.

Aynı zamanda siparişlerinin durumu buradan sorgulayabilir:
=> Bekleyen siparişler "Pending" olarak beklemeye alınır ve admin tarafından eğer onaylanırsa transfer süreci başlar:
Database'de şu şekilde konumlandırılmıştır bu kısım:
Pending
Shipped
Delivered
Cancelled
Returned
Refund
Olarak ayrılmaktadır.




---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
									         -Proje yapısı-

DATABASE:

Bu projede, MSSQL veritabanını tercih ettim. MSSQL, güçlü ve ölçeklenebilir bir ilişkisel veritabanı yönetim sistemi olduğu için benim için bir öncelik oldu.
Migration özelliğini kullanarak, veritabanı şemasındaki yapısal değişiklikleri yönettim. Bu sayede, veritabanında yeni tablolar ekleyebildim, mevcut tablolara sütunlar ekleyip silebildim ve ilişkileri tanımlayabildim.
Migration kullanmamın nedenleri ise şunlardır:

=>Veritabanı şemasında yapısal değişiklikler yapmam gerektiğinde kolaylıkla yönetebilmek için migration özelliğini kullandım.
=>Yeni tablolar, sütunlar veya ilişkiler ekleyebildim veya mevcut olanları değiştirebildim.
=>Migration, veritabanı şemasının kod tabanıyla senkronize olmasını sağlayarak güncellemeleri daha kontrol edilebilir hale getirdi.
=>Farklı ortamlarda (geliştirme, test, üretim) veritabanı şemasını tutarlı bir şekilde yönetebilmek için migration kullanmayı tercih ettim.

PM> add-migration added-tables
Build started...
Build succeeded.

Gerekli parametre değerlerini belirtip, uyumluluklarını ayarladıktan sonra tablolarımı başarıyla içeri aktardım.(Raporun sonunda Database Tabloları yer alacaktır.)

=> Klasörün içerisinde Database'ime ait backup dosyaları el almaktadır.
=> Tüm CRUD İşlemleri başarıyla tamamlanmıştır.

İlişkiler:

ShoppingCart ve Cart tabloları arasında 1-çok ilişki bulunmaktadır. Bir ShoppingCart'a birden fazla Cart kaydı bağlanabilir.
Computer ve Cart tabloları arasında 1-çok ilişki bulunmaktadır. Bir Computer'a birden fazla Cart kaydı bağlanabilir.
Computer ve Genre tabloları arasında 1-çok ilişki bulunmaktadır. Bir Genre'e birden fazla Computer kaydı bağlanabilir.
Order ve OrderDetail tabloları arasında 1-çok ilişki bulunmaktadır. Bir Order'a birden fazla OrderDetail kaydı bağlanabilir.
Order ve OrderStatus tabloları arasında 1-çok ilişki bulunmaktadır. Bir OrderStatus'a birden fazla Order kaydı bağlanabilir.
User ve ShoppingCart tabloları arasında 1-çok ilişki bulunmaktadır. Bir User'a birden fazla ShoppingCart kaydı bağlanabilir.

Çapraz Tablo Kayıt Örnekleri:

Cart Tablosu:

Id: 1
ShoppingCartId: 1
ComputerId: 1
Quantity: 2
UnitPrice: 1500.00
Computer Tablosu:

Id: 1
ComputerName: "HP Pavilion"
CompanyName: "HP"
Price: 3000.00
Image: "hp_pavilion.png"
GenreId: 1
Genre Tablosu:

Id: 1
GenreName: "Laptop"
Order Tablosu:

Id: 1
UserId: "exampleuser"
CreateDate: 2023-06-11 15:30:00
OrderStatusId: 2
IsDeleted: 0
OrderDetail Tablosu:

Id: 1
OrderId: 1
ComputerId: 1
Quantity: 1
UnitPrice: 1500.00
OrderStatus Tablosu:

Id: 1
StatusId: 1
StatusName: "Pending"
ShoppingCart Tablosu:

Id: 1
UserId: "exampleuser"
IsDeleted: 0
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

								            -KATMANLI MİMARİ YAPISI-

Kullandığım uygulama katmanlı bir mimariye sahiptir. Katmanlı mimari, uygulamaların farklı işlevlerini mantıksal katmanlara bölen ve bu katmanlar arasında düzenli iletişim sağlayan bir yaklaşımdır.

Uygulamamda aşağıdaki katmanları kullanarak katmanlı mimariyi uyguladım:

Sunum Katmanı (Presentation Layer):
Bu katman, kullanıcı arayüzünün bulunduğu yerdir. Kullanıcıların uygulama ile etkileşimde bulunmasını sağlar. Razor View yapısı ile HTML, CSS ve JavaScript kullanarak kullanıcı arayüzünü oluşturdum. Bootstrap ve jQuery gibi teknolojileri kullanarak kullanıcı arayüzünü geliştirdim.

Uygulama Katmanı (Application Layer):
Bu katman, kullanıcı arayüzü ile veritabanı arasındaki iletişimi yönetir. Kullanıcının taleplerini alır, gerekli iş mantığını uygular ve veritabanı işlemlerini gerçekleştirir. Bu katmanda, kontrolörler ve hizmet sınıfları (service classes) yer alır. ASP.NET Core MVC framework'ü ile bu katmanı oluşturdum ve gerekli işlemleri gerçekleştirdim.

Veri Erişim Katmanı (Data Access Layer):
Bu katman, veritabanı ile doğrudan iletişimi sağlar. Entity Framework Core ile bu katmanı oluşturdum. Veritabanına erişim için gerekli sorguları ve işlemleri gerçekleştirir. Bu katmanda veritabanı tablolarına karşılık gelen model sınıfları (entity classes) ve veritabanı bağlantısı yapılandırmaları yer alır.

Veritabanı Katmanı (Database Layer):
Bu katman, gerçek veritabanını temsil eder. Veritabanı yönetim sistemine bağlı olarak kullanılan veritabanı sunucusunda oluşturulan tablolar ve ilişkileri bulunur.


---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

									  -Kullanıcı Girişi ve Yetkilendirme İşlemleri-

Bu projede, kullanıcı girişi ve yetkilendirme işlemlerini gerçekleştirmek için session yapısı kullanılmıştır. Kullanıcılar, uygulamaya giriş yapabilmekte ve oturumlarını başlatmaktadır. Bu sayede, kullanıcıların uygulama içerisindeki kişisel bilgilere erişmesi ve yetkilendirilmiş işlevlere ulaşması sağlanmaktadır.

Opsiyonel olarak yetkilendirme yapmak, projeye ek bir değer katmaktadır. Bu şekilde, farklı kullanıcı rollerine (ör. yönetici, müşteri) ve yetkilere sahip kullanıcılara özelleştirilmiş erişim kontrolü sağlanabilmektedir. Yetkilendirme, kullanıcılara sadece yetkilerine uygun işlevleri kullanma imkanı tanıyarak güvenlik ve veri bütünlüğünü sağlamaktadır.

Session yapısı, kullanıcının oturum bilgilerini geçici bir süre boyunca saklamak için kullanılan bir mekanizmadır. Bu sayede, kullanıcının oturumu boyunca kimlik doğrulama bilgileri ve diğer önemli veriler tutulabilir. Kullanıcının uygulamada gezinirken, farklı sayfalar arasında bilgilerin korunmasını ve tutarlı bir kullanıcı deneyimi sağlanmasını sağlar.

Kullanıcı girişi ve yetkilendirme işlemleri, kullanıcılara kişiselleştirilmiş deneyimler sunmak, güvenliği artırmak ve belirli işlevlere erişimi kontrol etmek için önemli bir bileşendir. Bu özellikler, uygulamanın kullanıcılar tarafından etkin ve güvenli bir şekilde kullanılabilmesini sağlamaktadır.



---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

									    -BootStrap Kullanımı Ve Nedeni-


Proje geliştirme sürecinde Bootstrap kullanma tercihinde bulundum. Bootstrap, popüler bir HTML, CSS ve JavaScript framework'üdür.

Bootstrap'in kullanımı, projede hızlı ve konsisten bir şekilde kullanıcı arayüzünün oluşturulmasını sağlamaktaydı.

Grid sistemine dayalı yapısı, kolaylıkla duyarlı (responsive) tasarımlar oluşturmayı sağladım.Bu sayede, farklı ekran boyutlarına uyumlu bir deneyim sunabildim.

Hazır bileşenlerin ve stillerin bulunması, kullanıcı arayüzünün hızlı bir şekilde oluşturulmasını ve düzenlenmesini kolaylaştırdı.

Projenin kullanıcı arayüzünde birlik ve tutarlılık sağlamak için Bootstrap kullanımı tercih edilmiştir.

Yararlanılan BootStrap Componentleri:
=> Card
=> Badge
Yararlanılan Icon Paketi:
=>Bootstrap Icons v1.3.0

!Bootstrap Form yapısı da proje içerisinde kullanıldı.
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

									    -Bootswatch Kullanımı Ve Nedeni-

Proje geliştirme sürecinde Bootswatch teması kullanma tercihinde bulundum. Bootswatch, Bootstrap framework'üne önceden tasarlanmış temalar sunan bir hizmettir.

Bootswatch, kullanıcı arayüzüne görsel bir stil ve tema uygulamayı kolaylaştırır. Farklı renk seçenekleri ve stiller sunarak, projenin görsel çekiciliğini artırır.

Tema seçenekleri arasından uygun olanı seçerek, projenin tarzını ve hissini hızlıca değiştirmemi sağladı.

Proje için uygun bir Bootswatch teması seçerek, görsel açıdan dikkat çekici bir kullanıcı deneyimi oluşturmayı hedefledim.

Morph arayüzünü baz alarak projemi geliştirdim.


---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
										 -IEnumerable Yapısı-


Bu projede, IEnumerable kullanılarak veri koleksiyonlarının döngülenebilir yapısı sağlandı ve veri işleme işlevselliği kolaylıkla gerçekleştirilebildi.

IEnumerable, bir koleksiyonun elemanlarının üzerinde döngü (iterasyon) yapmayı mümkün kılan bir arayüzü temsil eder.
Bu sayede, verileri tek tek elde etmek veya veriler üzerinde işlemler yapmak için foreach döngüsü veya LINQ (Language Integrated Query) gibi sorgu ifadelerini kullanabilmekteyiz.


---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


											-GEREKSİNİMLER-
İşletim Sistemi:

Windows, Linux veya macOS gibi işletim sistemlerinden biri.

.NET Core SDK:

Uygulamanın geliştirilmesi ve çalıştırılması için .NET Core SDK'nın yüklü olması gerekmektedir. .NET Core SDK, projenin .NET Core bileşenlerini derleyip çalıştırmanızı sağlar.

Kod Editörü:

Uygulama kodunun yazılması ve düzenlenmesi için bir kod editörüne ihtiyaç vardır. Örneğin, Visual Studio Code, Visual Studio, JetBrains Rider veya başka bir uyumlu kod editörü kullanılabilir.

ASP.NET Core MVC ve Entity Framework Core:

Uygulama, ASP.NET Core MVC ve Entity Framework Core ile geliştirilmiştir. Bu nedenle, geliştirme ortamınızda bu bileşenlerin yüklü ve kullanılabilir durumda olması gerekmektedir.

Veritabanı Sunucusu:

Uygulama, veritabanı işlemleri için bir veritabanı sunucusuna ihtiyaç duyar.MSSQL Kullanımı proje için önerilir. Bu sunucunun kurulumu ve yapılandırması, uygulamanın gereksinimlerine uygun olarak yapılmalıdır. 

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
LinkedIn:	https://www.linkedin.com/in/yigitcetinkaya/
Github:  	https://github.com/Ctnn




