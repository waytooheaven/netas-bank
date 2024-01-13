# netas-bank

Merhaba,

Migration'ı conn str'i değiştirip kendiniz yapmanız lazım. Environment'ta set ediliyor genel bir conn. str.

Abstract ve sealed yaygın kullandım. Sizin polymorphism'e göre banka seçilimi dediğiniz pattern strategy pattern gibi duruyor. Yalnız yine bankID'ye bağlıyız.

Genelde ortak kullanımları inherit ettim. C#'in bind'ini kullandım.
