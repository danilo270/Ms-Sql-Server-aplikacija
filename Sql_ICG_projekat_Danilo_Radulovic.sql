create table dbo.Firma(
id_firme smallint not null primary key,
ime nchar(30) not null,
mesto nchar(30),
vlasnik nchar(20) not null,
);

create table dbo.sektor(
id_sekt smallint not null primary key,
ime_sekt  nchar(20) not null,
vodja_sektora nchar(30),
id_firme smallint foreign key references Firma(id_firme),
);

create table dbo.projekti(
 id_proj smallint not null primary key,
 ime_proj nchar(30) not null,
 id_sekt smallint foreign key references sektor(id_sekt),
 id_radnika smallint foreign key references radnik(id_radnika),
 pocetak_proj datetime,
 kraj_proj datetime,
);

create table dbo.radnik(
	id_radnika smallint not null primary key,
	ime nchar(30) not null,
	prezime nchar(30) not null,
	plata float,
	id_proj smallint foreign key references projekti(id_proj),
	dat_zap datetime,
);
alter table dbo.projekti
add foreign key (id_radnika) references radnik(id_radnika);