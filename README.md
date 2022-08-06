Klasör içersinde databasecreation.sql dosyası ile veritabanı tekrar istenilen MSSQL versiyonu ile çalıştırılabilir. Program Winforms'un araç kutusu ile geliştirilmiştir.
Ancak Dev-Express araçları ile Revize edilecektir. Program sql üzerinde "ServerName : . " ayarlanmıştır.Programın kısaca özelliklerinden bahsedecek olursak;
Personel 
Stok 
Maaş Sistemi
Lastik Depo
İşlem Kaydı
Muhasebe
Servis
Satış
Geri Alınma
gibi arayüz özelliklerine sahiptir.Kısım kısım anlatacak olursak;
-Personel-
Çalışanların tüm bilgileri kullanıcı adı , şifre gibi bilgileri, yeri geldiğinde silinebileceği, yeri geldiğinde bilgi güncellemesi için tüm arayüz tasarlanmıştır.

-Stok-
Mağaza içerisinde bulunan tüm ürünler,ürünün adet fiyatı,yeni eklenecek olan ürünler,olan ürünlerin stok güncellemesi için tüm arayüz tasarlanmıştır.

-Maaş Sistemi-
İçerisinde tüm personelin maaşların tutulduğu,gerektiğinde maaş güncellemesi yapıldığı ve satılan her üründe toplanılan prim miktarı, prim eklendiğinde toplam maaş durumu görülebilmesi için tüm arayüz tasarlanmıştır.

-Lastik Depo-
Müşterilerin ücret karşılığı sahip olup saklanmasını istediği lastiklerin eklendiği depo kontrol arayüzüdür.

-İşlem Kaydı-
Oluşabilecek olan tüm risklere karşı hırsızlık veya izinsiz işlemlerin tespit edildiği sadece Admin Kullanıcı ile giriş yapılan savunma merkezidir.
Çalışma mantığı ise stok ekle, giriş işlemleri, ürün ekleme,silme,satışında her defasında çalışan bilgisayarda butona tıklandığında işlemi veritabanına 
hangi bilgisayardan yapıldıysa işlemci seri numarası ile kayıt eder ki programı incelediğinizde her arayüze giriş için login bilgileri istemekte 
bu şekilde yapmamın sebebi ise düzenbazlık yapan veya teşebbüste olan kişiyi şüphe duyulmaksızın bir şekilde bulmak için tasarlanmıştır.

-Satış-
Adındanda anlaşıldığı gibi ürün satılması için gerekli olan arayüzdür detay olarak personel primi burda hesaplanır her işlemi yapan satış elemanına %2 prim sattığı ürün değerinden hesaplanıp maaş sistemine eklenir.

-Geri Al-
Olası bir durumda cayma durumu veya garanti durumunda ürünün geri alındığı zamanda nedeni ile eklenebilen arayüzdür.

-Muhasebe-
İstenilen gün arasında ne zaman ne satıldığı veya servisten kazanılan günlük,aylık, yıllık veya istenilen aralıkta görülmesini sağlayan merkezdir.

Dipnot: Verdiğim sqlkodunda Admin kullanıcı istenildiğinde veritabanı üzerinden admininfo tablosundaki değerler değiştirilerek kullanılabilir ancak default olarak benim eklediğim değerler Admin ID: bayiiotomasyon , Sifre : 123456789'dır.
 
