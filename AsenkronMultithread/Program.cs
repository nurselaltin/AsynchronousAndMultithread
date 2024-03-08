
#region Thread Sınıfı
//class Program
//{
//  private static void Main(string[] args)
//  {
//    Thread thread = new(()=>   //(obj) : Parametreli thread
//    {
//      for (int i = 0; i < 10; i++)
//      {
//        Console.WriteLine($"Worker Thread {i}"); 
//      }
//    });
//    thread.Start();

//    for (int i = 0; i < 10; i++)
//    {
//      Console.WriteLine($"Main Thread {i}");
//    }


//  }
//}
#endregion

#region Thread Id 

//Notlar ; 
////ThreadId değerine alma yöntemleri
//int threadId = Thread.CurrentThread.ManagedThreadId;
//int threadId2 = System.Environment.CurrentManagedThreadId;

//class Program
//{
//  private static void Main(string[] args)
//  {
//    Console.WriteLine("Main Thread ");
//    Console.WriteLine(Environment.CurrentManagedThreadId);
//    Console.WriteLine(AppDomain.GetCurrentThreadId());
//    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

//    Thread thread = new(() =>
//    {
//      Console.WriteLine("Worker 1 Thread ");
//      Console.WriteLine(Environment.CurrentManagedThreadId);
//      Console.WriteLine(AppDomain.GetCurrentThreadId());
//      Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//    });
//    thread.Start();
//    Thread thread2 = new(() =>
//    {
//      Console.WriteLine("Worker 2 Thread ");
//      Console.WriteLine(Environment.CurrentManagedThreadId);
//      Console.WriteLine(AppDomain.GetCurrentThreadId());
//      Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//    });
//    thread2.Start();
//  }
//}

#endregion


#region IsBackground 

//class Program
//{
//  private static void Main(string[] args)
//  {
//    Thread thread = new(() =>
//    {
//      int i = 0;
//      while (i >= 0)
//      {
//        i--;
//        Thread.Sleep(1000);
//      }
//      Console.WriteLine("Worker Thread işlemini tamamladı");
//    });
//    thread.Start();
//    thread.IsBackground = false; //Worker Thread işi bitince program sonlanacak
//    //thread.IsBackground = true; //Main Thread işi bitince program sonlanacak
//    Console.WriteLine("Main Thread işlemini tamamladı.");
//  }
//}

#endregion


#region Thread State 

//class Program
//{
//  private static void Main(string[] args)
//  {
//    Thread thread = new(()=>
//    {
//      int i = 0;
//      while (i >= 0)
//      {
//        i--;
//        Thread.Sleep(1000);
//      }
//      Console.WriteLine("Worker Thread işlemini tamamladı");
//    });
//    thread.Start();
//    //Thread durumdeğişince yazdır.Durunca yazdırmayı bırak

//    //Durum al
//    System.Threading.ThreadState state = System.Threading.ThreadState.WaitSleepJoin; 

//    while (true)
//    {
//        //Durdu döngüden çık
//        if (thread.ThreadState == System.Threading.ThreadState.Stopped)
//          break;

//        //Thread durum değişimi kontrol
//        if(state != thread.ThreadState) 
//        {
//          state = thread.ThreadState;
//          Console.WriteLine(state);
//        }
//    }
//    Console.WriteLine("Main Thread işlemini tamamladı.");
//  }
//}

#endregion

#region Locking 

//int i = 1; //Ortak kaynak

//  object _lock = new object();
//Thread thread1 = new(() =>
//{
//  lock (_lock) //Kiritik olan kısmı locklıyoruz
//  {
//    while (i < 10) //Kritik Bölge
//    {
//      i++;
//      Console.WriteLine($"Thread 1 : {i}");
//    }
//  }
//});

//Thread thread2 = new(() =>
//{
//  lock (_lock) //Kiritik olan kısmı locklıyoruz
//  {
//    while (i > 0) //Kritik Bölge
//    {
//      i--;
//      Console.WriteLine($"Thread 2 : {i}");
//    }
//  }
//});
//thread1.Start();
//thread2.Start();
//Console.ReadLine();
#endregion

#region Sleep 

// Thread thread = new(() =>
// {
//     for (int i = 0; i < 10; i++)
//     {
//       Console.WriteLine(i);
//       Thread.Sleep(1000); //Diğer thread zaman kazandırıyoruz
//     }
// });
//thread.Start();
//Console.ReadLine();

#endregion

#region Join 

//int i = 1; //Ortak kaynak
//Object _lock = new Object();
//Thread thread1 = new(() =>
//{
//  for (int i = 0; i < 10; i++)
//  {
//    Console.WriteLine($"Thread 1 : {i}");
//  }
//});

//Thread thread2 = new(() =>
//{
//  for (int i = 0; i < 10; i++)
//  {
//    Console.WriteLine($"Thread 2 : {i}");
//  }
//});
//thread1.Start();
//thread1.Join();
//thread2.Start();
//Console.ReadLine();
#endregion

#region Thread İptal Etme 
//bool stop = false;
//Thread thread = new(() =>
//{

//  while (true)
//  {
//    if (stop) break;
//    Console.WriteLine("asajbdh");
//  }
//  Console.WriteLine("Thread görevini tamamladı.");
//});

//thread.Start();
//Thread.Sleep(1000);
//stop = true;
//Console.ReadLine();

#endregion

#region Spinning
//bool threadCondition = true;
//Thread thread1 = new(() =>
//{
//  while (true)
//  {
//    if (threadCondition)  //Spinning koşul
//    {
//      for (int i = 1; i <= 10; i++)
//        Console.WriteLine($"Thread 1: {i}");
//      threadCondition = false;

//      break;
//    }
//  }
//});

//Thread thread2 = new(() =>
//{
//  while (true)
//  {
//    if (!threadCondition)
//    {
//      for (int i = 10; i > 0; i--)
//        Console.WriteLine($"Thread 2: {i}");
//      threadCondition = true;

//      break;
//    }
//  }

//});
//thread1.Start();
//thread2.Start();
#endregion

#region Monitor.Enter - Monitor.Exit
//Object _lock = new Object();
//int i = 0;
//Thread thread1 = new(() =>
//{
//  try
//  {
//    Monitor.Enter(_lock);
//    for (int i = 1; i < 10; i++)
//      Console.WriteLine($"Thread 1: {i}");
//  }
//  finally { Monitor.Exit(_lock); } // Hata alma durumunda lock çözer
//});

//Thread thread2 = new(() =>
//{
//  try
//  {
//    Monitor.Enter(_lock);
//    for (int i = 1; i < 10; i++)
//      Console.WriteLine($"Thread 2: {i}");
//  }
//  finally { Monitor.Exit(_lock); }
//});

//thread1.Start();
//thread2.Start();

#endregion


#region Monitor.TryEnter
//using System.ComponentModel.Design;

//Object _lock = new object();
//int i = 0;

//Thread thread1 = new(() =>
//{
//     var result = Monitor.TryEnter(_lock, 3);
//     if (result)
//		   try
//		   {
//		       for (int i = 1; i < 10; i++)
//            Console.WriteLine($"Thread 1: {i}");
//		   }
//		   finally { Monitor.Exit(_lock); }
//     else  Console.WriteLine("3 saniyede kilit alamadım.");
//});

//Thread thread2 = new(() =>
//{
//	  var result = Monitor.TryEnter(_lock, 4);
//	  if (result)
//	  	try
//	  	{
//	           for (int i = 1; i < 10; i++)
//            Console.WriteLine($"Thread 2: {i}");
//	  	}
//	  	finally { Monitor.Exit(_lock); }
//	  else  Console.WriteLine("4 saniyede kilit alamadım.");
//});

//thread1.Start();	
//thread2.Start();	

#endregion

#region LockTaken
//Object _lock = new Object();
//int i = 0;
//Thread thread1 = new(() =>
//{
//  bool _lockTaken = false;
//  Monitor.Enter(_lock, ref _lockTaken);

//  try
//  {
//    if (_lockTaken)
//    {
//      for (int i = 1; i < 10; i++)
//        Console.WriteLine($"Thread 1: {i}");
//    }
//  }
//  finally
//  {

//    if (!_lockTaken)
//    {
//      Monitor.Exit(_lock);
//    }
//  }
//});
//thread1.Start();
#endregion


#region Mutex
//Mutex mutex = new ();
//int i = 0;
//Thread thread1 = new Thread(()=>
//{
//    mutex.WaitOne ();
//    for ( i = 1; i < 10; i++)
//     Console.WriteLine($"Thread 1: {i}");
//    mutex.ReleaseMutex ();
//});

//Thread thread2 = new Thread(() =>
//{
//  mutex.WaitOne();
//  for (i = 1; i < 10; i++)
//    Console.WriteLine($"Thread 2: {i}");
//  mutex.ReleaseMutex();
//});

//thread1.Start ();
//thread2.Start ();

#endregion

#region Mutex - Single Application

//class Program
//{
//  static Mutex _mutex;
//  static string _programName = "Example Project";
//  private static void Main(string[] args)
//  {
//    Mutex.TryOpenExisting(_programName, out _mutex);
//    if (_mutex == null)
//    {
//      _mutex = new Mutex(true, _programName);
//      Console.WriteLine(_programName + " ayakta.");
//      Console.ReadLine();
//    }
//    else
//    {
//      _mutex.Close();
//      return;
//    }

//  }

//}
#endregion
#region Semaphore/SemaphoreSlim
//List<int> numberList = new List<int>();
//Semaphore _semaphore = new Semaphore(2, 2);
//Thread thread1 = new(() =>
//{
//   _semaphore.WaitOne();
//   int i = 0;
//  Console.WriteLine("Thread1 başladı");
//  while (i < 10)
//    Console.WriteLine($"Thread1 {++i}");
//    numberList.Add(i);
//  _semaphore.Release();
//  Console.WriteLine("Thread1 işi bitti");
//});

//Thread thread2 = new(() =>
//{
//  _semaphore.WaitOne();
//  int i = 11;
//  Console.WriteLine("Thread2 başladı");
//  while (i < 20)
//    Console.WriteLine($"Thread2 {++i}");
//  numberList.Add(i);
//  _semaphore.Release();
//  Console.WriteLine("Thread2 işi bitti");
//});

//Thread thread3 = new(() =>
//{
//  _semaphore.WaitOne();
//  int i = 21;
//  Console.WriteLine("Thread3 başladı");
//  while (i < 30)
//    Console.WriteLine($"Thread3 {++i}");
//  numberList.Add(i);
//  _semaphore.Release();
//  Console.WriteLine("Thread3 işi bitti");
//});

//thread1.Start();
//thread2.Start();
//thread3.Start();
#endregion

#region Volatile Keyword
//class Program
//{
//  volatile static int i;
//  // static int i;
//  private static void Main(string[] args)
//  {
//    Run();
//  }

//  public static void Run()
//  {
//    //azalt
//    //yazdır
//    //arttır

//    Thread thread1 = new(() =>
//    {
//      while (true) { i++; };
//    });

//    //Volitile keyword kullanmadığımızda Data Registerdan alacağı kısım
//    Thread thread2 = new(() =>
//    {
//      while (true)
//      {
//        Console.WriteLine(i);
//      }
//    });

//    Thread thread3 = new(() =>
//    {
//      while (true) { i--; };
//    });

//    thread1.Start();
//    thread2.Start();
//    thread3.Start();
//  }
//}


#endregion

#region Volitile Sınıfı
//class Program
//{
//   static int i;

//  private static void Main(string[] args)
//  {
//    Run();
//  }

//  public static void Run()
//  {
//    //azalt
//    //yazdır
//    //arttır

//    Thread thread1 = new(() =>
//    {
//      while (true) 
//        Volatile.Write(ref i, Volatile.Read(ref i) + 1);
//    });

//    Thread thread2 = new(() =>
//    {
//      while (true)
//      {
//        Console.WriteLine(Volatile.Read(ref i));
//      }
//    });

//    Thread thread3 = new(() =>
//    {
//      while (true)
//        Volatile.Write(ref i, Volatile.Read(ref i) - 1);
//    });

//    thread1.Start();
//    thread2.Start();
//    thread3.Start();
//  }
//}


#endregion

#region Interlocked 

//int i = 0;

//Thread thread1 = new(() =>
//{
//  while (true)
//    //i++;
//    Interlocked.Increment(ref i); // Güvenli ve atomik bir şekilde i değeri 1 arttıracak
//});

//Thread thread2 = new(() =>
//{
//  while (true)
//  {
//    Console.WriteLine(i);
//    Thread.Sleep(1000);
//  }

//});

////Thread thread3 = new(() =>
////{
////  while (true)
////    //i--;
////    Interlocked.Decrement(ref i); // Güvenli bir şekilde i değerini 1 azaltacak
////});

//thread1.Start();
//thread2.Start();
//thread3.Start();

//CompareExchange
//int sharedValue = 0;

//int oldValue = Interlocked.CompareExchange(ref sharedValue, 1, 0); //sharedValue değeri 0 ise değerini 1 yap

//Console.WriteLine($"Eski değer:{oldValue}");
//Console.WriteLine($"Yeni değer:{sharedValue}");

#endregion

#region Spinlock
//int value = 0;
//SpinLock spinLock = new SpinLock();

//Thread thread1 = new(() =>
//{
//	bool _lockTaken = false;
//  try
//  {
//    spinLock.Enter(ref _lockTaken);

//    if (_lockTaken)
//    {
//      for (int i = 0; i < 999; i++)
//        Console.WriteLine($"Thread1 : {++value}");
//    }
//  }
//  finally { spinLock.Exit(); }
//});

//Thread thread2 = new(() =>
//{
//  bool _lockTaken = false;
//  try
//  {
//    spinLock.Enter(ref _lockTaken);

//    if (_lockTaken)
//    {
//      for (int i = 0; i < 999; i++)
//        Console.WriteLine($"Thread2 : {value--}");
//    }
//  }
//  finally { spinLock.Exit(); }
//});

//thread1.Start();
//thread2.Start();

//Console.ReadLine();
#endregion

#region SpinWait
//bool waitMood = false; bool condition = false;
////Uzun süreli beklediğimiz senaryo
//Thread thread1 = new Thread(() =>
//{
//   while (true)
//   {
//     if (waitMood) { 
//        continue;
//     }

//     if (!condition)
//     {
//       continue;
//     }

//     Console.WriteLine("Thread1 işliyor...");
//   }
//});
////Daha az maliyet / daha performanslı
//Thread thread2 = new(()=>
//{
//  while (true)
//  {
//    SpinWait.SpinUntil(() =>
//    {
//      return waitMood || condition;
//    });

//    Console.WriteLine("Thread2 işliyor...");
//  }
//});

//thread1.Start();
//thread2.Start();
//Console.ReadLine();
#endregion

#region MemoryBarrier

//int i = 0;

//Thread writeThread = new(() =>
//{
//  while (true)
//  {
//    Interlocked.Increment(ref i);
//    //i değişkenin güncel değerinin diğer threadler tarafından görülebilmesini sağlıyor
//    Thread.MemoryBarrier();

//  }
//});

////------------------------------------

//Thread readThread = new(() =>
//{
//  while (true)
//  {
//    //i değerinin en güncel halini okumak için kullanılır.
//    Thread.MemoryBarrier();
//  }
//});

//writeThread.Start();
//readThread.Start();
//Console.ReadLine();

#endregion

#region AutoResetEvent

//AutoResetEvent autoResetEvent = new AutoResetEvent(false); // false değerini verince sinyal verebilecek bir modda oluyor.
//Thread thread1 = new(() => 
//{
//  Console.WriteLine("Thread1");
//  autoResetEvent.Set(); // sinyal veriyor
//});

////Thread2, thread1 işini bitirince veya içeride bir koşulu sağlayınca işlemine başlayacak.
//Thread thread2 = new(() =>
//{
//  //Thread1 sinyalini bekliyor
//  autoResetEvent.WaitOne();
//  Console.WriteLine("Thread2");
//  autoResetEvent.Set(); // sinyal veriyor
//});

////Thread3, thread1 işini bitirince veya içeride bir koşulu sağlayınca işlemine başlayacak.
//Thread thread3 = new(() =>
//{
//  //Thread1 sinyalini bekliyor
//  autoResetEvent.WaitOne();
//  Console.WriteLine("Thread3");
//  autoResetEvent.Set(); // sinyal veriyor
//});

////Sonuç:AutoResetEvent'te bekleyen threadlerden sadece 1 tanesi sinyali alabilir.
////Yukarıda thread1 sinyal verince ya thread2 ya da thread3 sinyali alabilecek.1-1 ilişkisi var burada


//thread1.Start();
//thread2.Start();
//thread3.Start();
#endregion