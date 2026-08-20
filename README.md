# Deskly

### Modern Workspace E-Commerce UI

Deskly, çalışma alanı ve masa aksesuarları üzerine tasarlanmış, ASP.NET Core MVC tabanlı bir e-ticaret arayüz projesidir.

Projenin ilk fazında; modern bir e-ticaret deneyimi oluşturmak, farklı ekran boyutlarında çalışan responsive bir arayüz geliştirmek ve klasik ürün listeleme deneyiminin yanında etkileşimli bir masa konfigüratörü tasarlamak hedeflenmiştir.

> **Proje Durumu:** Faz 1 — Frontend geliştirmeleri tamamlandı.

---

## 🇬🇧 English Summary

Deskly is a frontend-focused workspace e-commerce project built with ASP.NET Core MVC.

The first phase focuses on responsive interface development, product discovery and an interactive desk configurator experience.

Backend commerce infrastructure, database integration and real payment operations are not part of the current phase.

---

## ✨ Faz 1'de Neler Yaptım?

- Responsive ana sayfa tasarımı
- Masaüstü, tablet ve mobil uyumluluk
- Ürün listeleme arayüzü
- Ürün detay sayfaları
- Ürün kategori alanları
- Öne çıkan ürünler carousel yapısı
- Etkileşimli masa konfigüratörü
- Ürün kartları ve tekrar kullanılabilir Razor partial yapıları
- Sepet arayüzü
- Wishlist arayüzü
- Blog arayüzü
- Responsive header ve navigasyon
- Tailwind CSS tabanlı UI geliştirmeleri
- JavaScript ile arayüz etkileşimleri

---

## 🖥️ Masa Konfigüratörü

Deskly'nin öne çıkan bölümlerinden biri etkileşimli masa konfigüratörüdür.

Bu bölüm klasik bir ürün kataloğundan farklı olarak kullanıcının masa ve çalışma alanı ürünlerini görsel bir düzen içerisinde inceleyebilmesi amacıyla tasarlanmıştır.

Konfigüratörün mevcut Faz 1 sürümü frontend deneyimine odaklanmaktadır.

---

## 🛠️ Kullanılan Teknolojiler

- ASP.NET Core MVC
- C#
- Razor Views
- Tailwind CSS
- JavaScript
- HTML
- CSS
- Responsive Web Design

---

## 🧩 Proje Mimarisi

Proje ASP.NET Core MVC yapısı kullanılarak geliştirilmiştir.

```text
Controllers/
Models/
Services/
ViewModels/
Views/
wwwroot/
```

Arayüz tarafında Razor Views ve tekrar kullanılabilir partial yapıları kullanılmıştır.

Statik dosyalar, ürün görselleri, CSS ve JavaScript dosyaları `wwwroot` altında yönetilmektedir.

---

## 📱 Responsive Tasarım

Arayüz geliştirilirken farklı ekran boyutları dikkate alınmıştır.

Özellikle:

- Desktop
- Laptop
- Tablet
- Mobile

ekranlarında ürün kartları, kategoriler, navigasyon ve diğer arayüz bileşenlerinin uyarlanması üzerine çalışılmıştır.

---

## 🚀 Projeyi Çalıştırma

Projeyi klonladıktan sonra bağımlılıkları yükleyin:

```bash
npm install
```

Tailwind CSS çıktısını oluşturun:

```bash
npm run css:build
```

ASP.NET Core uygulamasını çalıştırın:

```bash
dotnet watch run
```

Geliştirme sırasında Tailwind CSS değişikliklerini izlemek için:

```bash
npm run css:watch
```

---

## 🗺️ Proje Durumu

### Faz 1 — Frontend

- [x] Ana sayfa
- [x] Responsive arayüz
- [x] Ürün listeleme
- [x] Ürün detay arayüzü
- [x] Kategori alanları
- [x] Öne çıkan ürünler carousel
- [x] Masa konfigüratörü
- [x] Sepet arayüzü
- [x] Wishlist arayüzü
- [x] Blog arayüzü

### Gelecekte Geliştirilebilecek Alanlar

Aşağıdaki özellikler mevcut Faz 1 kapsamında tamamlanmış özellikler değildir:

- Veritabanı entegrasyonu
- Gerçek kullanıcı authentication sistemi
- Kalıcı sepet ve wishlist verileri
- Yönetim paneli
- Sipariş yönetimi
- Ödeme altyapısı
- Backend API / endpoint entegrasyonları

---

## 👩‍💻 Geliştirici

**İrem Tilkioğlu**

Frontend odaklı portföy projesi.
