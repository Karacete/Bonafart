# Merhabalar!
Bonafart, Google Play Store üzerinde yayınlamak üzere geliştirdiğim ilk ciddi oyundur. Öncelikle size kısaca oyunu tanıtmak istiyorum. 

## Bonafart Nedir?
- Bonafart, minimal ve etkileyici bir platform oyunudur. Sizler, sevimli karakterimiz Bonafart'ı kontrol ederek engelleri aşmalı ve hedefe ulaşmalısınız. 
Bonafart, basit kontoller ama zorlayıcı seviyelerle sizi ekrana bağlayacak bir oyundur. Oyun istediğiniz her yerde oynayabilmeniz için kısa bölümler halinde yapılmıştır. 
Minimal tasarım ve sakin müzikler sizlere rahatlatıcı bir deneyim sunar. Her seviyede farklı engeller ve zorluklar sizi bekliyor. 
Sonuç olarak Bonafart sadece bir karakterin engelleri aşarak ilerlediği basit bir platform oyunudur. Oyuna bakmak isterseniz
[buraya](https://play.google.com/store/apps/details?id=com.MEKAGAMES.Bonafart&pcampaignid=web_share) tıklayınız.
 - Şimdi size içeriğinden bahsetmek istiyorum.
   
 ## Mekanikler
1.

```
    private void FixedUpdate()
    {
        
        rb.velocity = new Vector3(yatayHareket * Time.deltaTime * runSpeed, rb.velocity.y, 0);
        if (!animasyon.GetBool("kosmaBittiMi"))
            StartCoroutine(KonumDegisikigi()); 
    }
```

- Bu kod parçası `FixedUpdate()` fonksiyonu içerisine yazılmıştır. Bu da her karede bu fonksiyonun çalışacağı anlamına geliyor. Şimdi içeriğine ve ne yaptığına bakalım. ***Rigidbody*** componentinden türetilmiş
  olan ***rb*** nesnesiyle kullandığımız `velocity` vektörü karakterin konumunu ayarlamamıza yardımcı olur. `if()` bloğu ise karakterin koşma animasyonu hala devam ediyorsa `StartCorotune(KonumDegisikligi)`
  çağırarak parantez içindeki fonksiyonun belli aralıklarla çalışmasını sağlar.
2.

  ```
  private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //Karakter icin "Ground" tagina sahip objeye çapma kontolcusu
        {
            zipladiMi = false; //ziplama sinirlayicisinin kapatilmasi
            animasyon.SetBool("ziplamaBittiMi", true); //ziplama animasyonunun baslayabilecegini belirtir.
        }
    }
```

- Bu kod parçası bize **zıplama** olayının sadece bir kere gerçekleşmesini yani karakterimiz yere değmeden zıplamasını önlüyor. Bu da karakterimizin sonsuz kere zıplamasının önüne geçiyor.

3.

```
    private void FixedUpdate()
    {
        if (collision.gameObject.CompareTag("Water") || collision.gameObject.CompareTag("FireBall"))
        {
            collision.collider.transform.SetParent(null);
            script.ShowInterstitial();
        }
    }
```

- Bu kod parçası **Water** ve **Fireball** tagına sahip objelere çarptığı zaman oyun kaybedilecektir ama karakter hareketli platformun üzerindeyse ileride de belirteceğim üzere alt obje olarak atanır
ve eğer alt obje şeklinde ölürse eğer Unity hata veriyor. Bunun önüne geçmek için ise önce karakterin parent objesi varsa ***null*** değerle parent objelikten çıkarıyoruz.
```
private void Start()
{
   script = GameObject.FindWithTag("AD").GetComponent<ADManagerScript>();
}
```

- Karakter öldüğünde reklam çıkması için `Start()`fonksiyonu içerisinde scripti atadığımız **script** değişkeniyle `ShowInterstitial()` fonksiyonunu çağırıyoruz.

4.

```
 public void IleriHareket()
    {
        yatayHareket = 1;
        sr.flipX = false;
        animasyon.Play("Kosma");
        animasyon.SetBool("kosmaBittiMi", false);
    }
```
- Oyuncunun gerekli butona basmasıyla karakterin ileri hareketini sağayan fonksiyondur. `FixedUpdate()` fonksiyonu içerisinde de görebileceğimiz gibi `yatayHareket`, karakterin yatayda hareketini sağlamaktadır. 1 değeri ise karakterin pozitif yöne yani ileriye gitmesini sağlar. `sr.flipX` ise karakter sprite'nın
ters çevrilmesini yani terse dönme işlemini false yapıyor. ***Kosma*** animasyonu çalışıyor ve animasyon çalıştığı için ***kosmaBittiMi*** sorgusu false oluyor.
