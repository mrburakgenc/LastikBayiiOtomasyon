create database bayiotomasyon

use bayiotomasyon

create table personel(
personelkimlikno varchar(11) unique,
personeladsoyad varchar(max),
personeltipi varchar(max),
personeladres varchar(max),
personeliban varchar(max),
personeltelefon varchar(max),
personelkadi varchar(max),
personelsifre varchar(max)
);

create table lastikdepo(
ldno int primary key identity(1,1),
ldmusteriadsoyad varchar(max),
ldmusteriplaka varchar(max),
ldmusterikimlikno varchar(max),
ldmusteritelefon varchar(11),
ldmusteriadres varchar(max),
ldlastiktipi varchar(max),
ldadet int,
ldraf int
);

create table muhasebe(
mno int primary key identity(1,1),
myapilanislem varchar(max),
mkazanc money,
mislemkimin varchar(max),
mislemtarihi datetime
);

create table maas(
mpersonelkimlikno varchar(11),
mpersoneladsoyad varchar(max),
mpersonelmaas money,
mpersonelprim money,
mpersoneltoplam money,
mpersoneliban varchar(max)
);

create table satilan(
sno int primary key identity(1,1),
smusteriadsoyad varchar(max),
surun varchar(max),
surunadi varchar(max),
surunebati varchar(max),
starih datetime,
surunmarka varchar(max),
surunadet int
);

create table gerialinan(
gno int primary key identity(1,1),
gmusteriadsoyad varchar(max),
gurun varchar(max),
gurunadi varchar(max),
gurunebati varchar(max),
gnedeni varchar(max),
gtarih datetime,
surunmarka varchar(max),
surunadet int
);

create table stok(
surunkodu varchar(max),
surunadi varchar(max),
suruntipi varchar(max),
surunebati varchar(max),
surunadet int,
suruntutar int,
surunmarka varchar(max)
);

create table servis(
plaka varchar(max),
yapilanislem varchar(max),
alinanucret int,
islemtarihi datetime
);

create table deporaf(
rafno int,
durum int
);

create table admininfo(
loginid varchar(max),
loginpass varchar(max)
);

create table islemcilogu(
islemciserino varchar(max),
islemtipi varchar(max),
islemtarihi datetime
);


insert into admininfo (loginid,loginpass) values ('bayiiotomasyon','123456789')

DECLARE @Counter INT 
SET @Counter=1
WHILE ( @Counter <= 50)
BEGIN
    insert into deporaf(rafno,durum) values(@Counter,'0')
    SET @Counter  = @Counter  + 1
END