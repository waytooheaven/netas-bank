# netas-bank

Merhaba,

Migration'ı conn str'i değiştirip kendiniz yapmanız lazım. Environment'ta set ediliyor genel bir conn. str.

Abstract ve sealed yaygın kullandım. Sizin polymorphism'e göre banka seçilimi dediğiniz pattern strategy pattern gibi duruyor. Yalnız yine bankID'ye bağlıyız.

Genelde ortak kullanımları inherit ettim. C#'in bind'ini kullandım.

Automapper, actionfilter, swagger kullandım. Fluent güzel olabilir, onu daha önce kullandım ama bu da mümkün. Immutable value type olan record'ları kullandım.

AsNoTracking kullandım.
