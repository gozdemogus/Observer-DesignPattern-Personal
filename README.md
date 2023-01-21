<h1 align="center">
  Observer Design Pattern
</h1>

### Nedir?

- [Behavioral](https://en.wikipedia.org/wiki/Behavioral_pattern) ya da Türkçedeki karşılığı olan "davranışsal" olarak anlandırılan tasarım desenlerindendir.

- "Subjects", "Publishers" veya "Observables" olarak adlandırılan nesnelerin durumlarında değişiklik olduğunda "Observers" ya da "Subscribers" olarak adlandırılan diğer nesnelerin bu durumdan haberdar edilmesi mantığına dayanır.

### Nerelerde Kullanılır?

- Birden çok takipçiye bildirim gönderilen sosyal medya uygulamaları.

- Yeni bir güncelleme varsa, bir uygulamanın tüm kullanıcılarını bilgilendiren uygulama pazarları.

- Herhangi bir ürünün stokta kalmaması durumunda yöneticileri veya kullanıcıları bilgilendiren veya ürün sevk edildiğinde kullanıcıları bilgilendiren e-ticaret uygulaması.

Örnekler çeşitlendirilebilir.

### Observer Tasarım Deseni Hakkında 5 Önemli Nokta:

- Subject tüm Observerların bir listesini barındırır.
- Subject observerlara abone olup, abonelikten çıkabilir.
- Subject durumunda bir değişiklik olduğunda ya da bir olay geliştiğinde tüm observerlara bunu bildirir.
- Subject ve observerlar birbirleri hakkında açık bilgiye sahip olmadıklarından loosely coupled olarak bağlanmışlardır.
- Uygulama değiştirilmeden yeni observerlar eklenip, uygulanabilir.

### Implementasyon
#### Observer Implementasyonu

Projede order statusu değisiklik gösterdiğinde IOrderObserver interface'ini implement ederek iş kurallarınıza uygun olan bildirim çeşidinin gönderilmesi amaçlanmıştır.

``` csharp
  public interface IOrderObserver
	{
        void Update(Order order);
  }
 ```
 Örneğin EmailObserver sınıfı için:
 ``` csharp
  public class EmailObserver : IOrderObserver
    {
        public void Update(Order order)
        {
           //burada email gönderme islemleri yapılıyor
        }
    }
 ```
 
 #### Subject Implementasyonu
 Publisher interface mutlaka ekleme ve çıkarma methodu bulundurmalıdır. Publisherlar subscriberlar ile yalnızca subscriber interface aracılığı ile haberleşmelidir. 
 
  ``` csharp
  public interface IOrderNotifier
    {
        // Subjecte bir siparis observerı ekle.
        void Attach(IOrderObserver observer);

        // Subjectten bir siparis observerı cikart.
        void Detach(IOrderObserver observer);

        // Tum siparis observerlarını bir olay hakkinda bilgilendir.
        void Notify(Order order);
    }
  ```
  Interface'i kimin implement edeceğini belirleme, burada observerların listesi tutulacak ve ekleme çıkarme methodları bulundurulacak:
   ``` csharp
public interface IOrderService : IOrderNotifier
    {
        void UpdateOrder(Order order);
    }
 ```
 
  ``` csharp
  public class OrderService : IOrderService
    {
        public List<IOrderObserver> Observers = new List<IOrderObserver>();

        public void UpdateOrder(Order order)
        {
            Notify(order);
        }

        public void Attach(IOrderObserver observer)
        {
            Observers.Add(observer);
        }

        public void Detach(IOrderObserver observer)
        {
            Observers.Remove(observer);
        }
    }
   ```
Notify methodu ile subscriber listesi içerisindeki abonelerin Update methodu çağırılır ve güncellenmis order nesnesi aktarılır.
   
``` csharp
    public void Notify(Order order)
        {
            foreach (var observer in Observers)
            {
                observer.Update(order);
            }
        }
   ``` 

### Çıktı

Projede subject olan siparişin statusu güncellendiğinde bağlı olan observer nesnemize gönderilen SMS ve Email senaryosu kurgulanmıştır.

<img width="953" alt="image" src="https://user-images.githubusercontent.com/107196935/212470965-c1536673-6636-4164-a69f-c355f5d5664f.png">

Siparişin durumu "Pending Payment" iken "Shipped" olarak güncellendiğinde, observer nesnesinin bundan haberdar edilmesi sağlanmıştır.

<img width="953" alt="image" src="https://user-images.githubusercontent.com/107196935/212472452-c9fd95ac-8875-4373-9089-e06b197abee1.png">

### Kaynak

- [EzzyLearning](https://www.ezzylearning.net/tutorial/observer-design-pattern-in-asp-net-core)
- [Wikipedia](https://en.wikipedia.org/wiki/Observer_pattern)



