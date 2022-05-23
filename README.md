# Hammadde Kurutma Analiz Sistemi
<h3 align="center">
 Seramiklerin ve Seramik Hammaddelerinin Bünyede Bulunan Su Miktarının  Elektrik Akımı Yardımı ile Hesaplanması
</h3>
<p>
Malzeme teknolojilerinin hızla geliştiği, yeni ve ileri malzemelerin kullanım alanlarının giderek çeşitlendiği ve otomasyonun öneminin giderek arttığı 21. yüzyılda kurutma, pişirme, yoğurma gibi yıllardır süregelen konular da gelişmelerden bağımsız düşünülemez. Böyle bir dönemde malzeme mühendisliği üzerine lisans eğitimime devam etmekte olan birisi olarak lise eğitimimin de verdiği bilgi birikimi ve daha sonrasında hobi olarak uğraştığım Arduino bilgilerimi kullanarak böyle bir proje yapmaya karar verdim. Bu projenin en güzel ve önemli tarafı tamamen otomasyon entegreli olabilecek şekilde geliştirilmesi ve ileride oluşturulacak yapay zekaların malzeme seçim algoritmalarında topladığım verilerin kullanılabilir olması. Bu projede başlıca aşağıdaki iki soruna çözüm aranmıştır.
</p>

<p>
1-) Seramik hammaddelerinde çamur hazırlama aşamasında, plastik özellik oluşturulması için su kullanılmaktadır. Kullanılan bu su, şekil vermeyi kolaylaştırırken diğer taraftan da pişirme esnasında çok büyük problemlere yol açabilmektedir. Karşılaşılan en büyük problem pişirme esnasında bünyede bulunan suyun buharlaşarak, şekillendirilmiş çamurda deformasyon oluşturmasıdır. Bunun en büyük nedeni pişirmeden önce, şekillenmiş malzemenin içerisinde gereğinden fazla su bulunmasıdır. Bünyede bulunan su, sıcaklık etkisi ile hızla buharlaşıp gaz hale geçtiğinden yapıda çatlaklar oluşturarak yüzeye çıkmaktadır. Bu deformasyonu engellemek için işletmeler, ürünleri pişirmeden önce bünyede bulunan su miktarı ile ilgili bilgi sahibi olmak için ağırlıkça analizler uygulamaktadır. Bu analizler genellikle kuru ağırlık ve plastik ağırlık ölçülerek yapılan analizlerdir.
</p>

<p>
  2-) Endüstride cam, tuğla, kiremit, seramik, refrakter hemen hemen üretim yapılan bütün tesislerde özel reçeteler bulunmaktadır. Özellikle toprak esaslı minerallerin kullanıldığı reçetelerde kullanılan hammaddenin nem oranı çok önemlidir. Hammaddenin içerdiği nem miktarı reçete hesabına dahil edilmezse reçetenin tutarlılığı bozulacak ve ürünlerde istenmeyen hatalar meydana gelecektir. Oluşturduğum sistem, numunelerde veya hammaddelerde nem oranı hesaplayabilmekte ve kurutmayı verileri ile birlikte kayıt altında tutabilmektedir.
</p>

<p>
  Şekillendirilmiş ürünlerde suyun bulunması ve suyun (saf su hariç) iletken olmasını göz önüne alarak ürüne gerilim uyguladığımızda akımın su üzerinden iletileceğini düşünerek böyle bir projeye yöneldim. Projemdeki veri akışı 2 önemli unsurdan oluşmaktadır. Bunlardan birisi Analog Digital Converter (ADC) entegresi diğeri ise Arduino programlanabilir kart.
</p>

### ARDUINO

<p>
  Arduino, mikrodenetleyici kartları ve yazılım paketinden oluşan bir programlama platformudur. Öğrencilerden mühendislere, her kesimden insana hitap edebilmesi için kolaylık ön planda tutularak tasarlanmıştır. Kart üzerindeki mini bilgisayar (mikrodenetleyici), yazacağımız programa göre giriş ve çıkış bağlantılarını kontrol eder.
</p>

### ANALOG DIGITAL CONVERTER (ADC)
<p>
  Analog Digital Converter entegre, adından da anlaşılabileceği üzere analog sinyali bizim dijital sistemimizin algılayabileceği dijital veri haline dönüştürür. Piyasa da çok çeşitli ADC entegreleri bulunmakla birlikte teknolojinin gelişmesiyle bu entegreler artık mikroişlemcilerin içerisine girmişlerdir. Mikroişlemcilerde bulunan entegreler genel olarak 10-12 bit çözünürlüktedirler. Daha fazla çözünürlüğe ihtiyacımız varsa harici olarak entegre şeklinde 16 ve 24 bit olan modellerini de üreticilerden bulunabilmektedir.
  </p>
  <p>
ADC entegreler her zaman bir referans voltajına ihtiyaç duyarlar. Genelde bu referans voltajı entegrenin ya da mikroişlemcinin besleme pininden direk olarak alınır. Benim kullanmış olduğum ADC entegrenin referans voltajı, Arduino üzerinde bulunan 5V çıkış pinidir ve ADC entegresi 10bittir.
  </p>

### SİSTEM KURU YA DA ISLAK OLDUĞUNU NASIL ANLAR? 
<p>
Sistem basit olarak normalde açık bir devre şeklinde düşünülebilir. Bu devreyi tamamlayacak olan şey bizim numunemizdir. Açık halde bırakılan +/- uçlarımız suyun metaller üzerinde oluşturduğu korozyon dikkate alınarak galvanize saç kullanılarak seçilmiştir. Numune üzerinde herhangi bir iletim sağlayan bileşen varsa (su gibi) devre kapanacak ve iletim sağlanacaktır.
</p>
<p>
ADC entegremiz 4,93Vluk bir referans voltajı ile beslenmektedir. Eğer açık olan devre yani +/- uçlarımız iletken bir metal ile tamamlanırsa referans voltajı olan 4,93V gerilimin tamamının uygulandığı sabittir ve ADC entegremiz bize digital çıkış olarak 4,93V=0 (yani direnç yok) değerini verir. Eğer açık olan devremiz yalıtkan bir malzeme ile tamamlanırsa 0V=1024 değerini vermektedir. Bizim numune üzerindeki su miktarını gözlemlediğimiz aralık bu 0-1024 aralığıdır. 
</p>
<p>
	Sistem yalıtkan bir malzeme ile tamamlandığında 1024 değerini vermesinin sebebi; 10bitlik entegre kullanıldığı için ikilik sistemde karşılığı 210 (1024) ‘dur. Dolayısı ile besleme voltajı bu 1024 değerine eşit olarak dağıtılır. Yani 4,93V / 1024bit = 4.814453*10-3 V/bit değeri sağlanır. Bu değer bit başına düşen gerilimi gösterir. Buradan yola çıkarak ADC den aldığımız 600bit gibi bir değer aslında devrede 2.8886 V gerilim olduğunu ifade eder.
</p>
<p>
	Numunenin bünyesinde bulunan hammaddelerin olduğu faz, bizim gerilimimizi düşüren direnç görevi görmektedir. Bünyedeki su ise elektronların üzerinden aktığı iletkenimiz. Bu mantıkla bünyede su olduğu sürece iletim olacağı ve yukarıda anlatılan ADC hesaplamaları göz önüne alınarak bünyedeki su artışı ile iletim fazının çoğalması ve bu sebeple de mobilite artması sonucu referans gerilimimizin artması gözlemlenmiştir.
</p>
<p>
	Çeşitli su emme değeri olan malzemelerde yaptığım gözlemler sonucunda ortalama 850 değerinin altına ıslak, üzerine ise kuru tanımlaması ekledim. Bu 850 değeri; 
850bit * 4.814453*10-3 V/bit= 4.092285 V gerilime denk gelmektedir.
</p>

### SİSTEM NASIL KARAR VERİR? 
<p>
Yazılım da edilebilir müdahale ile Arduino’nun, ADC denetlemesini 1000ms (1 saniye) olarak ayarladım. Bu sayede Arduino her saniye ADC den gelecek olan dijital veriyi işlemektedir. Gelen veri örneğin 980 (4.7181V) değeri gibi ≥ 850 şeklinde bir veri ise oluşturduğum döngüler neticesinde numunenin kuru olduğunu algılamakta ya da gelen veri 650 (3.1293V) gibi ≤ 850 şeklinde ise ıslak olduğunu algılamaktadır. Bu karara varan mikrodenetleyici digital çıkışlardan, fanın bağlı olduğu pine elektrik göndererek numune ıslak ise fanı çalıştırmakta kuru ise fanı durdurmaktadır. Fan temsilidir asıl amaç burada röle kullanılarak fırının gerilim hattına bağlantı yapılmasıdır.
</p>

### VERİ AKIŞI
<p>
Visual Studio da C# dili ile ve Microsoft Access ile oluşturduğum veritabanını birleştirerek yaptığım yazılımda saniye saniye mikrodenetleyiciye gelen verileri veritabanında kayıt altına aldım. Aldığım kayıtlarda ölçümün yapıldığı tarih, saat, ölçümün analog değeri, numune durumu (Kuru/Islak) ve tahmini nem oranı değerlerinin kaydını saniye saniye tutmaktayım.
</p>
<p>
Tahmini nem oranı kısmında, sisteme eklenecek olan ağırlık sensörü verileri işlenecektir. Şu an elimde bulunmadığı için basit matematik ile şu adımları izledim, bünyede su yokken yani %0 su değerinde aslında %100 kuru anlamına gelmektedir. %100 kurulukta 1024 değerini alıyorsam, 600 değerini aldığımda (600*100) /1024 orantısını kullanarak % tahmini kuruluk değerini buldum. Bu değeri 100’den çıkararak tahmini nem oranının verisini aldım. 
</p>
<p>
Analog değer Arduinoya bağlı olan ADC entegresinden, numune durumu verisi ise oluşturulan döngülerden çıkan sonuçlara göre alınmaktadır. 
</p>

### VERİ TOPLAMA
<p>
-Şekildeki oluşturduğum arayüzde sol üst tarafta programın çalıştığı bilgisayardan gelen tarih ve saat verileri bulunmakta. 
</p>
<p>
-COM5 yazılı olan comboBox Arduino’nun bağlı olduğu bilgisayardaki USB sürücüsünün seçileceği kısımdır. 
</p>
<p>
-Başla butonu ile veri akışı başlatılır durdur butonu ile ise bu akış durdurulur. Durdur butonu veri akışının sadece arayüze ulaşan kısmını durdurur. Arka planda Arduino yazılımında veriler işlenmeye devam etmektedir. 
</p>
<p>
-Sağ taraftaki, üstte olan değerlerin yazdığı listBox verilerin anlık olarak akıp listelendiği kısımdır. Altındaki kısım ise durumu kaydet butonuna basıldığında verilerin geçici olarak (program kapatılana kadar) kayıt edildiği verilerin gösterildiği kısımdır. 
</p>
<p>
-Sol taraftaki veritabanını görüntüle butonu rengi kurutma yapıldığı sürece numunenin ıslak olduğunu gösteren mavi renge, kuru olduğunda ise sarı renge dönmektedir. Bu butona basıldığında veritabanına kaydedilmiş olan bütün verilerin listelendiği yeni bir arayüz açılmaktadır. Açılan arayüz aşağıda gösterilmiştir.
</p>
<p>
-Kurutucu Durumu yazısının yanındaki label, kurutucunun durumu hakkında, Kurutma işlemi yapılıyor ya da Kurutma işlemi sona erdi şeklinde bilgi vermektedir. 
</p>
<p>
-Verileri temizle butonu sağ tarafta yukarıdaki listBoxın içerisindeki anlık veri akışını temizlemektedir. Bu butonun koyulma sebebi, program hiç kapatılmadan 24 saat çalışırsa 86400 saniyeden 86400 tane veri birikecek. Bu birikmelerin önüne geçmek için kullanıcı istediği zaman bu buton aracılığı ile gereksiz verileri silebilmektedir. 
</p>
<p>
-Numune Adı (Kodu) kısmının altındaki TextBox, ideal kuruluğu kayıt altına alınacak numunenin adının, kodunun ya da kompozisyonunun (%20 feldspat gibi) kullanıcı tarafından girilecek bilginin eklendiği kısımdır. 
</p>
<p>
-Durumu kaydet butonu, tecrübeli kurutma çalışanları tarafından gözlemlenen malzemenin ideal kuruluğa ulaştığında basacağı butondur. Böylece hangi numunenin hangi analog değerde hangi nem oranında ideal kuruluğa ulaştığının bilgisi kayıt altına alınacaktır.
</p>

### HEDEFLENEN

<p>
Oluşturduğum yazılım sayesinde piyasada bulunan bütün seramik çamurların ideal kurutma verilerini toplamak, bu verileri kullanıp süreden bağımsız ve malzeme denetimine dayalı sistemi oluşturup kurutma fırınlarına entegre etmek. Bu sayede işletmeleri ek personel maliyetlerinden kurtarmak ve insan hata payı faktörünü ortadan kaldırarak, daha stabil ürünlerin pişirilmesini, böylece ürünlerde oluşan deformasyonları engellemek. 
</p>
<p>
Giriş kısmında da bahsettiğim üzere endüstrinin yapay zekaya doğru ilerlemesi ve bu yapay zekanın gelişimi sonucu malzeme üretim reçetelerini yapay zekaların hazırlayabileceği dönemlere çok uzak değiliz. Yapay zekalar Big Dataları işleyip daha sonra bu verileri en ideal şekilde kullanma konusunda oldukça iyi olduklarını sosyal medya reklam algoritmalarında ve dil çeviri algoritmalarında kanıtlamışlardır. Gelecekte bu algoritmalar malzeme biliminde, malzemelerle ilgili bütün verileri kullanarak hangi özellikte ürün isteniyorsa ona göre reçete hazırlayabilecek boyutlara gelecektir. Bu kısımda şirketlerin en büyük eksikleri sayısal verilerinin az olması olacaktır. Yapılan sistem sayesinde kurutma değerinin % ağırlık oranı dışında sayısal bir başka değerinin elde edilebileceğini kanıtlamaya çalıştım. Bu ve bunun gibi birçok veri bu yapay zekalarda algoritmalara dahil edileceğini düşünmekteyim.
</p>
