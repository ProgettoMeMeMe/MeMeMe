USE [MeMeMe]
GO
/****** Object:  Table [dbo].[Actigrafo]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actigrafo](
	[idPaziente] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AE]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AE](
	[idAE] [int] IDENTITY(1,1) NOT NULL,
	[idPaziente] [int] NOT NULL,
	[dataInserimento] [datetime] NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[dataAE] [date] NOT NULL,
	[note] [nvarchar](max) NULL,
 CONSTRAINT [PK_AE] PRIMARY KEY CLUSTERED 
(
	[idAE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AEDettaglio]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AEDettaglio](
	[idAEDettaglio] [int] IDENTITY(1,1) NOT NULL,
	[idAE] [int] NOT NULL,
	[tipoEvento] [int] NOT NULL,
	[tipoEventoAltro] [nvarchar](50) NULL,
	[serietaEvento] [int] NOT NULL,
	[reazioneFarmaco] [int] NOT NULL,
	[serietaGrado] [int] NOT NULL,
	[dataInizio] [datetime] NOT NULL,
	[dataFine] [datetime] NULL,
	[outcome] [int] NOT NULL,
 CONSTRAINT [PK_AEDettaglio] PRIMARY KEY CLUSTERED 
(
	[idAEDettaglio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Anagrafica]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anagrafica](
	[idPaziente] [int] IDENTITY(1,1) NOT NULL,
	[codPaziente] [char](9) NULL,
	[userName] [varchar](50) NOT NULL,
	[data] [datetime] NOT NULL,
	[famiglia] [int] NOT NULL,
	[parentela] [int] NOT NULL,
	[randomizzazioneDieta] [int] NOT NULL,
	[dataRandomizzazioneDieta] [datetime] NULL,
	[randomizzazioneTrattamento] [varbinary](128) NULL,
	[dataRandomizzazioneTrattamento] [datetime] NULL,
	[nome] [varchar](25) NOT NULL,
	[cognome] [varchar](25) NOT NULL,
	[indirizzo] [varchar](50) NOT NULL,
	[provincia] [varchar](2) NOT NULL,
	[comune] [varchar](50) NOT NULL,
	[localita] [varchar](30) NULL,
	[cap] [varchar](5) NOT NULL,
	[datanascita] [datetime] NOT NULL,
	[comuneNascita] [varchar](50) NOT NULL,
	[cfiscale] [varchar](16) NOT NULL,
	[sesso] [char](1) NOT NULL,
	[statocivile] [int] NULL,
	[istruzione] [int] NULL,
	[professione] [int] NULL,
	[telefonoFisso] [varchar](20) NULL,
	[telefonoLavoro] [varchar](20) NULL,
	[telefonoCellulare] [varchar](20) NOT NULL,
	[email] [varchar](50) NULL,
	[medicoNome] [varchar](50) NOT NULL,
	[medicoCognome] [varchar](50) NOT NULL,
	[medicoIndirizzo] [varchar](50) NULL,
	[medicoCitta] [varchar](50) NULL,
	[medicoTelefonoStudio] [varchar](20) NULL,
	[medicoTelefonoCellulare] [varchar](20) NULL,
	[riferimentoNome] [varchar](25) NOT NULL,
	[riferimentoCognome] [varchar](25) NOT NULL,
	[riferimentoTelefono] [varchar](20) NULL,
	[consensoPrivacy] [bit] NOT NULL,
	[consensoInformato] [bit] NOT NULL,
	[studioGeneticaPartecipazione] [bit] NOT NULL,
	[studioGeneticaUtilizzo] [bit] NOT NULL,
	[altriStudiConservazione] [bit] NOT NULL,
	[studioGeneticaContatti] [bit] NOT NULL,
	[dataConsensoInformato] [datetime] NULL,
	[dropOut] [bit] NOT NULL,
	[fromTevere] [date] NULL,
	[fromTevereToMeMeMeId] [int] NULL,
	[idAnonimo] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Anagrafica] PRIMARY KEY CLUSTERED 
(
	[idPaziente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Antropometria]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Antropometria](
	[idStatoRegistro] [int] NOT NULL,
	[dataInserimento] [datetime] NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[data] [datetime] NOT NULL,
	[altezza] [decimal](5, 1) NOT NULL,
	[peso] [decimal](5, 2) NOT NULL,
	[circonferenzaVita] [decimal](5, 2) NOT NULL,
	[circonferenzaFianchi] [decimal](5, 2) NOT NULL,
	[pressioneMax] [int] NOT NULL,
	[pressioneMin] [int] NOT NULL,
	[pulsazioni] [int] NOT NULL,
	[terapiaIpertensione] [bit] NOT NULL,
	[terapiaIpercolesterolemia] [bit] NOT NULL,
	[terapiaIpertrigliceridemia] [bit] NOT NULL,
	[cardioaspirina] [bit] NOT NULL,
	[note] [text] NULL,
 CONSTRAINT [PK_Antropometria] PRIMARY KEY CLUSTERED 
(
	[idStatoRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[User_Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[Centro] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssegnazioneFarmaco]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssegnazioneFarmaco](
	[idAssegnazioneRegistro] [int] NOT NULL,
	[dataInserimento] [datetime] NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[flaconiAssegnati] [int] NOT NULL,
	[dataConsegna] [datetime] NOT NULL,
	[pilloleAssunte] [int] NOT NULL,
	[effettiCollaterali] [bit] NOT NULL,
	[osservazioni] [text] NULL,
	[dosaggioPieno] [int] NOT NULL,
 CONSTRAINT [PK_AssegnazioneFarmaco] PRIMARY KEY CLUSTERED 
(
	[idAssegnazioneRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssegnazioniElenco]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssegnazioniElenco](
	[idAssegnazioneElenco] [int] NOT NULL,
	[descrizione] [varchar](100) NOT NULL,
	[descrizioneForm] [varchar](100) NOT NULL,
	[fase] [varchar](100) NOT NULL,
	[istruzioni] [varchar](max) NULL,
	[posologiaFlaconi] [nvarchar](100) NOT NULL,
	[durataMesi] [int] NOT NULL,
	[dosaggioPieno] [int] NOT NULL,
	[mezzoDosaggio] [bit] NOT NULL,
 CONSTRAINT [PK_AssegnazioniElenco] PRIMARY KEY CLUSTERED 
(
	[idAssegnazioneElenco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssegnazioniRegistro]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssegnazioniRegistro](
	[idAssegnazioneRegistro] [int] IDENTITY(1,1) NOT NULL,
	[idPaziente] [int] NOT NULL,
	[idAssegnazioneElenco] [int] NOT NULL,
	[DataApertura] [datetime] NOT NULL,
	[DataChiusura] [datetime] NULL,
	[Completamento] [bit] NOT NULL,
 CONSTRAINT [PK_AssehnazioneRegistro] PRIMARY KEY CLUSTERED 
(
	[idAssegnazioneRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttivitaFisica]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttivitaFisica](
	[idStatoRegistro] [int] NOT NULL,
	[dataInserimento] [datetime] NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[data] [datetime] NOT NULL,
	[attivitaVigorose] [smallint] NOT NULL,
	[attivitaVigoroseSettimanaDurata] [smallint] NULL,
	[attivitaVigoroseSettimanaNrNr] [bit] NOT NULL,
	[attivitaVigoroseTipo] [smallint] NULL,
	[attivitaVigoroseGiornoDurata] [varchar](5) NULL,
	[attivitaVigoroseGiornoNrNr] [bit] NOT NULL,
	[camminata] [smallint] NOT NULL,
	[camminataSettimanaDurata] [smallint] NULL,
	[camminataSettimanaDurataNsNr] [bit] NOT NULL,
	[camminataTipo] [smallint] NULL,
	[camminataGiornoDurata] [varchar](5) NULL,
	[camminataGiornoDurataNsNr] [bit] NOT NULL,
	[attivitaModerata] [smallint] NOT NULL,
	[attivitaModerataSettimanaDurata] [smallint] NULL,
	[attivitaModerataSettimanaDurataNsNr] [bit] NOT NULL,
	[attivitaModerataTipo] [smallint] NULL,
	[attivitaModerataGiornoDurata] [varchar](5) NULL,
	[attivitaModerataGiornoDurataNsNr] [bit] NOT NULL,
	[attivitaSedentariaSettimanaDurata] [smallint] NULL,
	[attivitaSedentariaSettimanaDurataNsNr] [bit] NOT NULL,
	[attivitaSedentariaTipo] [smallint] NULL,
	[attivitaSedentariaMercolediDurata] [varchar](5) NULL,
	[attivitaSedentariaMercolediDurataNsNr] [bit] NOT NULL,
	[sonnoLetto] [varchar](5) NULL,
	[sonnoAddormentamento] [smallint] NULL,
	[alzata] [varchar](5) NULL,
	[durataSonno] [smallint] NULL,
	[qualitaSonno] [smallint] NULL,
 CONSTRAINT [PK_AttivitaFisica] PRIMARY KEY CLUSTERED 
(
	[idStatoRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comuni]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comuni](
	[CodiceIstatComune] [char](6) NOT NULL,
	[CodiceRegione] [char](2) NOT NULL,
	[CodiceProvincia] [char](3) NOT NULL,
	[CodiceComune] [varchar](50) NOT NULL,
	[Comune] [nvarchar](255) NOT NULL,
	[ProvinciaSigla] [varchar](2) NOT NULL,
	[Provincia] [nvarchar](255) NULL,
 CONSTRAINT [PK_Comuni_1] PRIMARY KEY CLUSTERED 
(
	[CodiceComune] ASC,
	[ProvinciaSigla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiarioDieta24]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiarioDieta24](
	[idStatoRegistro] [int] NOT NULL,
	[dataInserimento] [datetime] NOT NULL,
	[ieri] [int] NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[data] [datetime] NOT NULL,
	[merendineNC] [bit] NOT NULL,
	[merendineCO] [bit] NOT NULL,
	[merendinePR] [bit] NOT NULL,
	[merendineCE] [bit] NOT NULL,
	[merendineFP] [bit] NOT NULL,
	[cioccolatoNC] [bit] NOT NULL,
	[cioccolatoCO] [bit] NOT NULL,
	[cioccolatoPR] [bit] NOT NULL,
	[cioccolatoCE] [bit] NOT NULL,
	[cioccolatoFP] [bit] NOT NULL,
	[bibiteNC] [bit] NOT NULL,
	[bibiteCO] [bit] NOT NULL,
	[bibitePR] [bit] NOT NULL,
	[bibiteCE] [bit] NOT NULL,
	[bibiteFP] [bit] NOT NULL,
	[bevandeAlcolicheNC] [bit] NOT NULL,
	[bevandeAlcolicheCO] [bit] NOT NULL,
	[bevandeAlcolichePR] [bit] NOT NULL,
	[bevandeAlcolicheCE] [bit] NOT NULL,
	[bevandeAlcolicheFP] [bit] NOT NULL,
	[latteNC] [bit] NOT NULL,
	[latteCO] [bit] NOT NULL,
	[lattePR] [bit] NOT NULL,
	[latteCE] [bit] NOT NULL,
	[latteFP] [bit] NOT NULL,
	[yogurtZuccheratoNC] [bit] NOT NULL,
	[yogurtZuccheratoCO] [bit] NOT NULL,
	[yogurtZuccheratoPR] [bit] NOT NULL,
	[yogurtZuccheratoCE] [bit] NOT NULL,
	[yogurtZuccheratoFP] [bit] NOT NULL,
	[yogurtBiancoNC] [bit] NOT NULL,
	[yogurtBiancoCO] [bit] NOT NULL,
	[yogurtBiancoPR] [bit] NOT NULL,
	[yogurtBiancoCE] [bit] NOT NULL,
	[yogurtBiancoFP] [bit] NOT NULL,
	[fruttaNC] [bit] NOT NULL,
	[fruttaCO] [bit] NOT NULL,
	[fruttaPR] [bit] NOT NULL,
	[fruttaCE] [bit] NOT NULL,
	[fruttaFP] [bit] NOT NULL,
	[verdureCrudeNC] [bit] NOT NULL,
	[verdureCrudeCO] [bit] NOT NULL,
	[verdureCrudePR] [bit] NOT NULL,
	[verdureCrudeCE] [bit] NOT NULL,
	[verdureCrudeFP] [bit] NOT NULL,
	[patateNC] [bit] NOT NULL,
	[patateCO] [bit] NOT NULL,
	[patatePR] [bit] NOT NULL,
	[patateCE] [bit] NOT NULL,
	[patateFP] [bit] NOT NULL,
	[verdureCotteNC] [bit] NOT NULL,
	[verdureCotteCO] [bit] NOT NULL,
	[verdureCottePR] [bit] NOT NULL,
	[verdureCotteCE] [bit] NOT NULL,
	[verdureCotteFP] [bit] NOT NULL,
	[paneBiancoNC] [bit] NOT NULL,
	[paneBiancoCO] [bit] NOT NULL,
	[paneBiancoPR] [bit] NOT NULL,
	[paneBiancoCE] [bit] NOT NULL,
	[paneBiancoFP] [bit] NOT NULL,
	[paneNeroNC] [bit] NOT NULL,
	[paneNeroCO] [bit] NOT NULL,
	[paneNeroPR] [bit] NOT NULL,
	[paneNeroCE] [bit] NOT NULL,
	[paneNeroFP] [bit] NOT NULL,
	[pizzaNC] [bit] NOT NULL,
	[pizzaCO] [bit] NOT NULL,
	[pizzaPR] [bit] NOT NULL,
	[pizzaCE] [bit] NOT NULL,
	[pizzaFP] [bit] NOT NULL,
	[grissiniNC] [bit] NOT NULL,
	[grissiniCO] [bit] NOT NULL,
	[grissiniPR] [bit] NOT NULL,
	[grissiniCE] [bit] NOT NULL,
	[grissiniFP] [bit] NOT NULL,
	[pastaAsciuttaNC] [bit] NOT NULL,
	[pastaAsciuttaCO] [bit] NOT NULL,
	[pastaAsciuttaPR] [bit] NOT NULL,
	[pastaAsciuttaCE] [bit] NOT NULL,
	[pastaAsciuttaFP] [bit] NOT NULL,
	[pastaRipienaNC] [bit] NOT NULL,
	[pastaRipienaCO] [bit] NOT NULL,
	[pastaRipienaPR] [bit] NOT NULL,
	[pastaRipienaCE] [bit] NOT NULL,
	[pastaRipienaFP] [bit] NOT NULL,
	[risoBiancoNC] [bit] NOT NULL,
	[risoBiancoCO] [bit] NOT NULL,
	[risoBiancoPR] [bit] NOT NULL,
	[risoBiancoCE] [bit] NOT NULL,
	[risoBiancoFP] [bit] NOT NULL,
	[risoIntegraleNC] [bit] NOT NULL,
	[risoIntegraleCO] [bit] NOT NULL,
	[risoIntegralePR] [bit] NOT NULL,
	[risoIntegraleCE] [bit] NOT NULL,
	[risoIntegraleFP] [bit] NOT NULL,
	[cerealiChiccoNC] [bit] NOT NULL,
	[cerealiChiccoCO] [bit] NOT NULL,
	[cerealiChiccoPR] [bit] NOT NULL,
	[cerealiChiccoCE] [bit] NOT NULL,
	[cerealiChiccoFP] [bit] NOT NULL,
	[fiocchiNonZuccheratiNC] [bit] NOT NULL,
	[fiocchiNonZuccheratiCO] [bit] NOT NULL,
	[fiocchiNonZuccheratiPR] [bit] NOT NULL,
	[fiocchiNonZuccheratiCE] [bit] NOT NULL,
	[fiocchiNonZuccheratiFP] [bit] NOT NULL,
	[fiocchiZuccheratiNC] [bit] NOT NULL,
	[fiocchiZuccheratiCO] [bit] NOT NULL,
	[fiocchiZuccheratiPR] [bit] NOT NULL,
	[fiocchiZuccheratiCE] [bit] NOT NULL,
	[fiocchiZuccheratiFP] [bit] NOT NULL,
	[legumiNC] [bit] NOT NULL,
	[legumiCO] [bit] NOT NULL,
	[legumiPR] [bit] NOT NULL,
	[legumiCE] [bit] NOT NULL,
	[legumiFP] [bit] NOT NULL,
	[carniRosseNC] [bit] NOT NULL,
	[carniRosseCO] [bit] NOT NULL,
	[carniRossePR] [bit] NOT NULL,
	[carniRosseCE] [bit] NOT NULL,
	[carniRosseFP] [bit] NOT NULL,
	[salumiNC] [bit] NOT NULL,
	[salumiCO] [bit] NOT NULL,
	[salumiPR] [bit] NOT NULL,
	[salumiCE] [bit] NOT NULL,
	[salumiFP] [bit] NOT NULL,
	[carniBiancheNC] [bit] NOT NULL,
	[carniBiancheCO] [bit] NOT NULL,
	[carniBianchePR] [bit] NOT NULL,
	[carniBiancheCE] [bit] NOT NULL,
	[carniBiancheFP] [bit] NOT NULL,
	[pesceNC] [bit] NOT NULL,
	[pesceCO] [bit] NOT NULL,
	[pescePR] [bit] NOT NULL,
	[pesceCE] [bit] NOT NULL,
	[pesceFP] [bit] NOT NULL,
	[formaggiNC] [bit] NOT NULL,
	[formaggiCO] [bit] NOT NULL,
	[formaggiPR] [bit] NOT NULL,
	[formaggiCE] [bit] NOT NULL,
	[formaggiFP] [bit] NOT NULL,
	[pietanzeNC] [bit] NOT NULL,
	[pietanzeCO] [bit] NOT NULL,
	[pietanzePR] [bit] NOT NULL,
	[pietanzeCE] [bit] NOT NULL,
	[pietanzeFP] [bit] NOT NULL,
	[nociNC] [bit] NOT NULL,
	[nociCO] [bit] NOT NULL,
	[nociPR] [bit] NOT NULL,
	[nociCE] [bit] NOT NULL,
	[nociFP] [bit] NOT NULL,
	[snackNC] [bit] NOT NULL,
	[snackCO] [bit] NOT NULL,
	[snackPR] [bit] NOT NULL,
	[snackCE] [bit] NOT NULL,
	[snackFP] [bit] NOT NULL,
	[uovaNC] [bit] NOT NULL,
	[uovaCO] [bit] NOT NULL,
	[uovaPR] [bit] NOT NULL,
	[uovaCE] [bit] NOT NULL,
	[uovaFP] [bit] NOT NULL,
	[zuccheroNC] [bit] NOT NULL,
	[zuccheroCO] [bit] NOT NULL,
	[zuccheroPR] [bit] NOT NULL,
	[zuccheroCE] [bit] NOT NULL,
	[zuccheroFP] [bit] NOT NULL,
	[saleNC] [bit] NOT NULL,
	[saleCO] [bit] NOT NULL,
	[salePR] [bit] NOT NULL,
	[saleCE] [bit] NOT NULL,
	[saleFP] [bit] NOT NULL,
	[olioExtravergineNC] [bit] NOT NULL,
	[olioExtravergineCO] [bit] NOT NULL,
	[olioExtraverginePR] [bit] NOT NULL,
	[olioExtravergineCE] [bit] NOT NULL,
	[olioExtravergineFP] [bit] NOT NULL,
	[burroNC] [bit] NOT NULL,
	[burroCO] [bit] NOT NULL,
	[burroPR] [bit] NOT NULL,
	[burroCE] [bit] NOT NULL,
	[burroFP] [bit] NOT NULL,
	[margarinaNC] [bit] NOT NULL,
	[margarinaCO] [bit] NOT NULL,
	[margarinaPR] [bit] NOT NULL,
	[margarinaCE] [bit] NOT NULL,
	[margarinaFP] [bit] NOT NULL,
	[altro1] [varchar](100) NULL,
	[altro1NC] [bit] NOT NULL,
	[altro1CO] [bit] NOT NULL,
	[altro1PR] [bit] NOT NULL,
	[altro1CE] [bit] NOT NULL,
	[altro1FP] [bit] NOT NULL,
	[altro2] [varchar](100) NULL,
	[altro2NC] [bit] NOT NULL,
	[altro2CO] [bit] NOT NULL,
	[altro2PR] [bit] NOT NULL,
	[altro2CE] [bit] NOT NULL,
	[altro2FP] [bit] NOT NULL,
	[altro3] [varchar](100) NULL,
	[altro3NC] [bit] NOT NULL,
	[altro3CO] [bit] NOT NULL,
	[altro3PR] [bit] NOT NULL,
	[altro3CE] [bit] NOT NULL,
	[altro3FP] [bit] NOT NULL,
	[altro4] [varchar](100) NULL,
	[altro4NC] [bit] NOT NULL,
	[altro4CO] [bit] NOT NULL,
	[altro4PR] [bit] NOT NULL,
	[altro4CE] [bit] NOT NULL,
	[altro4FP] [bit] NOT NULL,
	[altro5] [varchar](100) NULL,
	[altro5NC] [bit] NOT NULL,
	[altro5CO] [bit] NOT NULL,
	[altro5PR] [bit] NOT NULL,
	[altro5CE] [bit] NOT NULL,
	[altro5FP] [bit] NOT NULL,
 CONSTRAINT [PK_DiarioDieta24] PRIMARY KEY CLUSTERED 
(
	[idStatoRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drop]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drop](
	[idDrop] [int] IDENTITY(1,1) NOT NULL,
	[idStatoRegistro] [int] NOT NULL,
	[dataInserimento] [datetime] NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[data] [datetime] NOT NULL,
	[dataUltimaAssunzione] [datetime] NULL,
	[idMotivazione] [int] NOT NULL,
	[motivazione] [varchar](max) NULL,
	[outcomePrimario] [tinyint] NOT NULL,
	[tumore] [tinyint] NULL,
	[tumoreDiagnosi] [nvarchar](max) NULL,
	[tumoreSede] [nvarchar](100) NULL,
	[cardiovascolare] [tinyint] NULL,
	[cardiovascolareDiagnosi] [nvarchar](max) NULL,
	[cardiovascolareDescrizione] [nvarchar](100) NULL,
	[diabeteTipo2] [tinyint] NULL,
	[altre] [tinyint] NULL,
	[altreDiagnosi] [nvarchar](max) NULL,
	[altreDescrizione] [nvarchar](100) NULL,
	[dataDiagnosiPrincipale] [date] NULL,
 CONSTRAINT [PK_Drop_1] PRIMARY KEY CLUSTERED 
(
	[idDrop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ELMAH_Error]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ELMAH_Error](
	[ErrorId] [uniqueidentifier] NOT NULL,
	[Application] [nvarchar](60) NOT NULL,
	[Host] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Source] [nvarchar](60) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[User] [nvarchar](50) NOT NULL,
	[StatusCode] [int] NOT NULL,
	[TimeUtc] [datetime] NOT NULL,
	[Sequence] [int] IDENTITY(1,1) NOT NULL,
	[AllXml] [ntext] NOT NULL,
 CONSTRAINT [PK_ELMAH_Error] PRIMARY KEY NONCLUSTERED 
(
	[ErrorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmergenzeLog]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmergenzeLog](
	[idEmergenza] [int] IDENTITY(1,1) NOT NULL,
	[dataRegistrazione] [datetime] NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[ricercaEsito] [varchar](20) NOT NULL,
	[ricerca] [varchar](50) NOT NULL,
	[adminChecked] [bit] NOT NULL,
 CONSTRAINT [PK_emergenzeLog] PRIMARY KEY CLUSTERED 
(
	[idEmergenza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KitFlaconiAssegnazione]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KitFlaconiAssegnazione](
	[idAssegnazione] [int] IDENTITY(1,1) NOT NULL,
	[Kit] [char](6) NOT NULL,
	[utente] [varchar](50) NOT NULL,
	[dataAssegnazione] [datetime] NOT NULL,
	[idPaziente] [int] NOT NULL,
	[idAssegnazioneElenco] [int] NOT NULL,
 CONSTRAINT [PK_KitFlaconiAssegnazione] PRIMARY KEY CLUSTERED 
(
	[idAssegnazione] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KitRandomizzazione]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KitRandomizzazione](
	[Kit] [char](6) NOT NULL,
	[Blocco] [int] NOT NULL,
	[TreatmentGroup] [varbinary](128) NOT NULL,
	[TreatmentGroupDescription] [varbinary](128) NOT NULL,
	[Contenuto] [nvarchar](50) NOT NULL,
	[DataConsegna] [datetime] NULL,
	[ScadenzaFarmaco] [datetime] NULL,
	[Lotto] [nvarchar](50) NULL,
	[Fornitore] [nvarchar](50) NOT NULL,
	[Reso] [bit] NOT NULL,
 CONSTRAINT [PK_KitRandomizzazioneMiPharm] PRIMARY KEY CLUSTERED 
(
	[Kit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUAE_Grado]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUAE_Grado](
	[idAEGrado] [int] NOT NULL,
	[grado] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LUAE_Grado] PRIMARY KEY CLUSTERED 
(
	[idAEGrado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUAE_Outcome]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUAE_Outcome](
	[idAEOutcome] [int] NOT NULL,
	[outcome] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LUAE_Outcome] PRIMARY KEY CLUSTERED 
(
	[idAEOutcome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUAE_TipoEvento]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUAE_TipoEvento](
	[idAETipoEvento] [int] NOT NULL,
	[TipoEvento] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LUAE_TipoEvento] PRIMARY KEY CLUSTERED 
(
	[idAETipoEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUDropMotivazioni]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUDropMotivazioni](
	[idMotivazione] [int] NOT NULL,
	[motivazione] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LU_Motivazioni] PRIMARY KEY CLUSTERED 
(
	[idMotivazione] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUIParentela]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUIParentela](
	[idParentela] [int] NOT NULL,
	[parentela] [varchar](30) NOT NULL,
 CONSTRAINT [PK_LUIParentela] PRIMARY KEY CLUSTERED 
(
	[idParentela] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUIstruzione]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUIstruzione](
	[idIstruzione] [int] NOT NULL,
	[istruzione] [varchar](20) NOT NULL,
 CONSTRAINT [PK_LUIstruzione] PRIMARY KEY CLUSTERED 
(
	[idIstruzione] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUProfessione]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUProfessione](
	[idProfessione] [int] NOT NULL,
	[professione] [varchar](20) NOT NULL,
 CONSTRAINT [PK_LUProfessione] PRIMARY KEY CLUSTERED 
(
	[idProfessione] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUStatoCivile]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUStatoCivile](
	[idStatoCivile] [int] NOT NULL,
	[statocivile] [varchar](20) NOT NULL,
 CONSTRAINT [PK_LUStatoCivile] PRIMARY KEY CLUSTERED 
(
	[idStatoCivile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUTipoTrattamento]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUTipoTrattamento](
	[idTipoTrattamento] [int] NOT NULL,
	[tipoTrattamento] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LUTrattamento] PRIMARY KEY CLUSTERED 
(
	[idTipoTrattamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MEDAS]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MEDAS](
	[idStatoRegistro] [int] NOT NULL,
	[dataInserimento] [datetime] NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[data] [datetime] NOT NULL,
	[d01] [int] NULL,
	[d02] [decimal](5, 1) NULL,
	[d03] [decimal](5, 1) NULL,
	[d04] [decimal](5, 1) NULL,
	[d05] [decimal](5, 1) NULL,
	[d06] [decimal](5, 1) NULL,
	[d07] [decimal](5, 1) NULL,
	[d08] [decimal](5, 1) NULL,
	[d09] [decimal](5, 1) NULL,
	[d10] [decimal](5, 1) NULL,
	[d11] [decimal](5, 1) NULL,
	[d12] [decimal](5, 1) NULL,
	[d13] [int] NULL,
	[d14] [decimal](5, 1) NULL,
 CONSTRAINT [PK_Medas] PRIMARY KEY CLUSTERED 
(
	[idStatoRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prelievo]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prelievo](
	[idStatoRegistro] [int] NOT NULL,
	[dataInserimento] [datetime] NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[data] [datetime] NOT NULL,
	[leucociti] [decimal](5, 2) NULL,
	[eritrociti] [decimal](5, 2) NULL,
	[emoglobina] [decimal](5, 1) NULL,
	[ematocrito] [decimal](5, 1) NULL,
	[MCV] [decimal](5, 1) NULL,
	[MCH] [decimal](5, 1) NULL,
	[MCHC] [decimal](5, 1) NULL,
	[RDW] [decimal](5, 1) NULL,
	[piastrine] [int] NULL,
	[MPV] [decimal](5, 1) NULL,
	[neutrofili_pc] [decimal](5, 1) NULL,
	[neutrofili_nm] [decimal](5, 2) NULL,
	[linfociti_pc] [decimal](5, 1) NULL,
	[linfociti_nm] [decimal](5, 2) NULL,
	[monociti_pc] [decimal](5, 1) NULL,
	[monociti_nm] [decimal](5, 2) NULL,
	[eosinofili_pc] [decimal](5, 1) NULL,
	[eosinofili_nm] [decimal](5, 2) NULL,
	[basofili_pc] [decimal](5, 1) NULL,
	[basofili_nm] [decimal](5, 2) NULL,
	[grandicellule_pc] [decimal](5, 1) NULL,
	[grandicellule_nm] [decimal](5, 2) NULL,
	[glicemia] [int] NOT NULL,
	[creatininemia] [decimal](5, 2) NOT NULL,
	[transaminasiGOT_AST] [int] NULL,
	[transaminasiGPL_ALT] [int] NULL,
	[gammaGlutammil] [int] NULL,
	[colesterolemia] [int] NOT NULL,
	[HDL] [int] NOT NULL,
	[LDL] [int] NULL,
	[trigliceridi] [int] NOT NULL,
	[EGFR] [decimal](5, 1) NULL,
	[urinePh] [varchar](50) NULL,
	[urineLeucociti] [varchar](50) NULL,
	[urineNitriti] [varchar](50) NULL,
	[urineAlbumina] [varchar](50) NULL,
	[urineGlucosio] [varchar](50) NULL,
	[urineChetoni] [varchar](50) NULL,
	[urineUrobinologico] [varchar](50) NULL,
	[urineBilirubina] [varchar](50) NULL,
	[urineEmoglobina] [varchar](50) NULL,
	[urinePesoSpecifico] [varchar](50) NULL,
	[urineAspetto] [varchar](50) NULL,
	[urineColore] [varchar](50) NULL,
	[urineEsameSedimento] [varchar](50) NULL,
	[note] [text] NULL,
 CONSTRAINT [PK_Prelievo] PRIMARY KEY CLUSTERED 
(
	[idStatoRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SAE]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SAE](
	[idSAE] [int] IDENTITY(1,1) NOT NULL,
	[idPaziente] [int] NOT NULL,
	[dataInserimento] [datetime] NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[studyDrug] [varchar](200) NOT NULL,
	[dosaggio] [int] NULL,
	[assunzioneSAE] [varchar](200) NOT NULL,
	[dataAssegnazionePeriodoProva] [datetime] NOT NULL,
	[dataUltimaAssunzione] [datetime] NOT NULL,
	[dataSAE] [datetime] NOT NULL,
	[diagnosi] [nvarchar](max) NOT NULL,
	[gravita] [int] NOT NULL,
	[relazioneCausale] [int] NOT NULL,
	[azioneIntrapresa] [varchar](200) NOT NULL,
	[inizioSAE] [datetime] NOT NULL,
	[fineSAE] [datetime] NULL,
	[reazioneArresto] [int] NOT NULL,
	[risomministrazioneFarmaco] [int] NOT NULL,
	[dataRisomministrazioneFarmaco] [datetime] NULL,
	[ripetizioneDopoRiassunzione] [int] NULL,
	[risultato] [int] NOT NULL,
	[eventoFatale] [int] NULL,
	[dataMorte] [datetime] NULL,
	[malattiaCausaSAE] [int] NULL,
	[concomitante1] [varchar](50) NULL,
	[concomitante1Diagnosi] [varchar](50) NULL,
	[concomitante1DoseGG] [varchar](50) NULL,
	[concomitante1DaQuanto] [varchar](50) NULL,
	[concomitante1DataInzio] [datetime] NULL,
	[concomitante1DataFine] [datetime] NULL,
	[concomitante1InCorso] [int] NULL,
	[concomitante1CauseSAE] [int] NULL,
	[concomitante1modificaConduzioneTrial] [int] NULL,
	[concomitante2] [varchar](50) NULL,
	[concomitante2Diagnosi] [varchar](50) NULL,
	[concomitante2DoseGG] [varchar](50) NULL,
	[concomitante2DaQuanto] [varchar](50) NULL,
	[concomitante2DataInzio] [datetime] NULL,
	[concomitante2DataFine] [datetime] NULL,
	[concomitante2InCorso] [int] NULL,
	[concomitante2CauseSAE] [int] NULL,
	[concomitante2modificaConduzioneTrial] [int] NULL,
	[concomitante3] [varchar](50) NULL,
	[concomitante3Diagnosi] [varchar](50) NULL,
	[concomitante3DoseGG] [varchar](50) NULL,
	[concomitante3DaQuanto] [varchar](50) NULL,
	[concomitante3DataInzio] [datetime] NULL,
	[concomitante3DataFine] [datetime] NULL,
	[concomitante3InCorso] [int] NULL,
	[concomitante3CauseSAE] [int] NULL,
	[concomitante3modificaConduzioneTrial] [int] NULL,
	[malattiaAllergiaRischio1] [varchar](50) NULL,
	[malattiaAllergiaRischio1DataInizio] [datetime] NULL,
	[malattiaAllergiaRischio1DataFine] [datetime] NULL,
	[malattiaAllergiaRischio1InCorso] [int] NULL,
	[malattiaAllergiaRischio1CausaPrimariaSAE] [int] NULL,
	[malattiaAllergiaRischio2] [varchar](50) NULL,
	[malattiaAllergiaRischio2DataInizio] [datetime] NULL,
	[malattiaAllergiaRischio2DataFine] [datetime] NULL,
	[malattiaAllergiaRischio2InCorso] [int] NULL,
	[malattiaAllergiaRischio2CausaPrimariaSAE] [int] NULL,
	[malattiaAllergiaRischio3] [varchar](50) NULL,
	[malattiaAllergiaRischio3DataInizio] [datetime] NULL,
	[malattiaAllergiaRischio3DataFine] [datetime] NULL,
	[malattiaAllergiaRischio3InCorso] [int] NULL,
	[malattiaAllergiaRischio3CausaPrimariaSAE] [int] NULL,
	[osservazioni] [nvarchar](max) NULL,
 CONSTRAINT [PK_SAE] PRIMARY KEY CLUSTERED 
(
	[idSAE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatiElenco]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatiElenco](
	[idStato] [int] NOT NULL,
	[descrizione] [varchar](100) NOT NULL,
	[descrizioneForm] [varchar](100) NOT NULL,
	[fase] [varchar](100) NOT NULL,
	[istruzioni] [nvarchar](max) NULL,
 CONSTRAINT [PK_StatiElenco] PRIMARY KEY CLUSTERED 
(
	[idStato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatiRegistro]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatiRegistro](
	[idStatoRegistro] [int] IDENTITY(1,1) NOT NULL,
	[idPaziente] [int] NOT NULL,
	[idStato] [int] NOT NULL,
	[DataApertura] [datetime] NOT NULL,
	[DataChiusura] [datetime] NULL,
	[Completamento] [bit] NOT NULL,
 CONSTRAINT [PK_StatiRegistro] PRIMARY KEY CLUSTERED 
(
	[idStatoRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StileDiVita]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StileDiVita](
	[idStatoRegistro] [int] NOT NULL,
	[dataInserimento] [date] NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[data] [date] NOT NULL,
	[mPreoccupazione] [bit] NOT NULL,
	[mRicerca] [bit] NOT NULL,
	[mStile] [bit] NOT NULL,
	[mAltro] [bit] NOT NULL,
	[motivazioneAltro] [nvarchar](200) NULL,
	[fumo] [int] NULL,
	[fumoFine] [int] NULL,
	[fumoInizio] [int] NULL,
	[fumoSigaretteMedia] [int] NULL,
	[fumoSigaretteMax] [int] NULL,
	[fumoSigari] [tinyint] NULL,
	[fumoPipa] [tinyint] NULL,
	[ipertensione] [tinyint] NOT NULL,
	[ipertensioneTrattamento] [tinyint] NULL,
	[patologiaApparatoCardiocircolatorio] [tinyint] NOT NULL,
	[pacAngina] [bit] NOT NULL,
	[pacCardiomiopatia] [bit] NOT NULL,
	[pacStenosi] [bit] NOT NULL,
	[pacAritmia] [bit] NOT NULL,
	[pacTIA] [bit] NOT NULL,
	[pacAltre] [bit] NOT NULL,
	[pacAltreTxt] [varchar](max) NULL,
	[patologiaApparatoRespiratorio] [tinyint] NOT NULL,
	[parAsma] [bit] NOT NULL,
	[parEnfisema] [bit] NOT NULL,
	[parAltre] [bit] NOT NULL,
	[parAltreTxt] [varchar](max) NULL,
	[patologiaApparatoDigerente] [tinyint] NOT NULL,
	[padGastrite] [bit] NOT NULL,
	[padUlcera] [bit] NOT NULL,
	[padPolipi] [bit] NOT NULL,
	[padDiverticolite] [bit] NOT NULL,
	[padErnia] [bit] NOT NULL,
	[padAltre] [bit] NOT NULL,
	[padAltreTxt] [varchar](max) NULL,
	[patologiaApparatoUrogenitale] [tinyint] NOT NULL,
	[pauNefrite] [bit] NOT NULL,
	[pauCalcolosi] [bit] NOT NULL,
	[pauInsufficienza] [bit] NOT NULL,
	[pauProstata] [bit] NOT NULL,
	[pauOvaio] [bit] NOT NULL,
	[pauUtero] [bit] NOT NULL,
	[pauAltre] [bit] NOT NULL,
	[pauAltreTxt] [varchar](max) NULL,
	[patologiaApparatoOsteoarticolare] [tinyint] NOT NULL,
	[paoArtrite] [bit] NOT NULL,
	[paoArtrosi] [bit] NOT NULL,
	[paoErnia] [bit] NOT NULL,
	[paoGotta] [bit] NOT NULL,
	[paoOsteoporosi] [bit] NOT NULL,
	[paoAltre] [bit] NOT NULL,
	[paoAltreTxt] [varchar](max) NULL,
	[patologiaSistemaNervoso] [tinyint] NOT NULL,
	[patParkinson] [bit] NOT NULL,
	[patAlzheimer] [bit] NOT NULL,
	[patEmicrania] [bit] NOT NULL,
	[patAltre] [bit] NOT NULL,
	[patAltreTxt] [varchar](max) NULL,
	[patologiaEndocrino] [tinyint] NOT NULL,
	[peTiroide] [bit] NOT NULL,
	[peIpofisi] [bit] NOT NULL,
	[peSurrene] [bit] NOT NULL,
	[peAltre] [bit] NOT NULL,
	[peAltreTxt] [varchar](max) NULL,
	[patologiaMetabolismo] [tinyint] NOT NULL,
	[pmColesterolo] [bit] NOT NULL,
	[pmTrigliceridi] [bit] NOT NULL,
	[pmGlicemia] [bit] NOT NULL,
	[pmUricemia] [bit] NOT NULL,
	[pmSteatosi] [bit] NOT NULL,
	[pmAltre] [bit] NOT NULL,
	[pmAltreTxt] [varchar](max) NULL,
	[patologiaOcchio] [tinyint] NOT NULL,
	[poCataratta] [bit] NOT NULL,
	[poGlaucoma] [bit] NOT NULL,
	[poRetinopatia] [bit] NOT NULL,
	[poMaculopatia] [bit] NOT NULL,
	[poAltre] [bit] NOT NULL,
	[poAltreTxt] [varchar](max) NULL,
	[altrePatologie] [tinyint] NOT NULL,
	[apPsoriasi] [bit] NOT NULL,
	[apLupus] [bit] NOT NULL,
	[apSclerodermia] [bit] NOT NULL,
	[apArtriteReumatoide] [bit] NOT NULL,
	[apAltre] [bit] NOT NULL,
	[apAltreTxt] [varchar](max) NULL,
	[patologieNoteTxt] [varchar](max) NULL,
	[mestruazioni] [int] NULL,
	[menopausa] [int] NULL,
	[mestruazioniDataUltima] [date] NULL,
	[mestruazioniDataUltimaNsNr] [bit] NOT NULL,
	[menopausaEta] [int] NULL,
	[mestruazioniCessazione] [int] NULL,
	[mestruazioniCessazioneEta] [int] NULL,
	[mestruazioniCessazioneTipoIntervento] [nvarchar](max) NULL,
	[mestruazioniCessazioneMotivazione] [nvarchar](max) NULL,
	[mestruazioniCessazioneAltro] [nvarchar](max) NULL,
	[mestruazioniCessazioneAltroMotivazione] [nvarchar](max) NULL,
	[estrogeni] [int] NULL,
	[terapiaOrmonale] [int] NULL,
	[terapiaOrmonaleTempo] [int] NULL,
	[pillolaContraccettiva] [int] NULL,
	[pillolaContraccettivaTempo] [int] NULL,
	[altriOrmonali] [int] NULL,
	[altriOrmonaliTempo] [int] NULL,
	[gravidanze] [int] NULL,
	[gravidanzeNumero] [int] NULL,
	[gravidanzeConcluse] [int] NULL,
	[gravidanzeEtaPrimofiglio] [int] NULL,
	[gravidanzeTentativi] [int] NULL,
	[gravidanzeCureOrmonali] [int] NULL,
	[stitichezza] [int] NULL,
	[stitichezzaLassativi] [int] NULL,
	[peso20Anni] [int] NULL,
	[pesoMax] [int] NULL,
	[pesoPrimeMestruazioni] [int] NULL,
 CONSTRAINT [PK_StileDiVita] PRIMARY KEY CLUSTERED 
(
	[idStatoRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trattamenti]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trattamenti](
	[idStatoRegistro] [int] NOT NULL,
	[dataInserimento] [datetime] NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[data] [datetime] NOT NULL,
 CONSTRAINT [PK_Trattamenti] PRIMARY KEY CLUSTERED 
(
	[idStatoRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrattamentiDettaglio]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrattamentiDettaglio](
	[idTrattamentoDettaglio] [int] IDENTITY(1,1) NOT NULL,
	[idStatoRegistro] [int] NOT NULL,
	[tipoTrattamento] [int] NOT NULL,
	[tipoTrattamentoAltro] [nvarchar](255) NULL,
	[trattamento] [nvarchar](255) NOT NULL,
	[doseGiornaliera] [nvarchar](255) NOT NULL,
	[motivo] [nvarchar](max) NOT NULL,
	[durata] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_TrattamentiDettaglio] PRIMARY KEY CLUSTERED 
(
	[idTrattamentoDettaglio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ValutazioneMetformina]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ValutazioneMetformina](
	[idStatoRegistro] [int] NOT NULL,
	[dataInserimento] [datetime] NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[dataConsegna] [datetime] NOT NULL,
	[dataTerminazione] [datetime] NULL,
	[pilloleAssunte] [int] NULL,
	[effettiCollaterali] [bit] NOT NULL,
	[osservazioni] [text] NULL,
 CONSTRAINT [PK_ValuazioneMeformina] PRIMARY KEY CLUSTERED 
(
	[idStatoRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_PazientiConMedasPrimoAnno]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_PazientiConMedasPrimoAnno]
AS
SELECT        idAnonimo
FROM            dbo.vSTATA_Medas
WHERE        (numRegistrazione = 2) AND (idAnonimo NOT IN
                             (SELECT        idAnonimo
                               FROM            dbo.vSTATA_Drop))
GO
/****** Object:  View [dbo].[v_StatoCorrente]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_StatoCorrente]
AS
SELECT        idPaziente, CASE WHEN MAX(idStato) <> 99 THEN MAX(idStato) WHEN
                             (SELECT        COUNT(*)
                               FROM            KitFlaconiAssegnazione
                               WHERE        idPaziente = StatiRegistro.idPaziente) < 2 AND MAX(idStato) = 99 THEN MAX(idStato) ELSE 100 END AS statocorrente
FROM            dbo.StatiRegistro
WHERE        (idStato < 100)
GROUP BY idPaziente
GO
ALTER TABLE [dbo].[Anagrafica] ADD  CONSTRAINT [DF_Anagrafica_codPaziente]  DEFAULT ('-') FOR [codPaziente]
GO
ALTER TABLE [dbo].[Anagrafica] ADD  CONSTRAINT [DF_Anagrafica_sesso]  DEFAULT ('?') FOR [sesso]
GO
ALTER TABLE [dbo].[Anagrafica] ADD  CONSTRAINT [DF_Anagrafica_studioGeneticaPartecipazione]  DEFAULT ((1)) FOR [studioGeneticaPartecipazione]
GO
ALTER TABLE [dbo].[Anagrafica] ADD  CONSTRAINT [DF_Anagrafica_studioGeneticaUtilizzo]  DEFAULT ((1)) FOR [studioGeneticaUtilizzo]
GO
ALTER TABLE [dbo].[Anagrafica] ADD  CONSTRAINT [DF_Anagrafica_altriStudiConservazione]  DEFAULT ((1)) FOR [altriStudiConservazione]
GO
ALTER TABLE [dbo].[Anagrafica] ADD  CONSTRAINT [DF_Anagrafica_studioGeneticaContatti]  DEFAULT ((1)) FOR [studioGeneticaContatti]
GO
ALTER TABLE [dbo].[Anagrafica] ADD  CONSTRAINT [DF_Anagrafica_dropOut]  DEFAULT ((0)) FOR [dropOut]
GO
ALTER TABLE [dbo].[Antropometria] ADD  CONSTRAINT [DF_Antropometria_terapiaIpertensione]  DEFAULT ((0)) FOR [terapiaIpertensione]
GO
ALTER TABLE [dbo].[Antropometria] ADD  CONSTRAINT [DF_Antropometria_terapiaIpercolesterolemia]  DEFAULT ((0)) FOR [terapiaIpercolesterolemia]
GO
ALTER TABLE [dbo].[Antropometria] ADD  CONSTRAINT [DF_Antropometria_terapiaIpertrigliceridemia]  DEFAULT ((0)) FOR [terapiaIpertrigliceridemia]
GO
ALTER TABLE [dbo].[Antropometria] ADD  CONSTRAINT [DF_Antropometria_terapiaIperglicemia]  DEFAULT ((0)) FOR [cardioaspirina]
GO
ALTER TABLE [dbo].[AssegnazioneFarmaco] ADD  CONSTRAINT [DF_AssegnazioneFarmaco_dosaggioPieno]  DEFAULT ((0)) FOR [dosaggioPieno]
GO
ALTER TABLE [dbo].[AssegnazioniElenco] ADD  CONSTRAINT [DF_AssegnazioniElenco_durataMesi]  DEFAULT ((0)) FOR [durataMesi]
GO
ALTER TABLE [dbo].[AssegnazioniElenco] ADD  CONSTRAINT [DF_AssegnazioniElenco_DosaggioPieno]  DEFAULT ((0)) FOR [dosaggioPieno]
GO
ALTER TABLE [dbo].[AssegnazioniElenco] ADD  CONSTRAINT [DF_AssegnazioniElenco_mezzoDosaggio]  DEFAULT ((0)) FOR [mezzoDosaggio]
GO
ALTER TABLE [dbo].[AttivitaFisica] ADD  CONSTRAINT [DF_AttivitaFisica_attivitaModerataSettimanaDurataNsNr]  DEFAULT ((1)) FOR [attivitaModerataSettimanaDurataNsNr]
GO
ALTER TABLE [dbo].[Drop] ADD  CONSTRAINT [DF__Drop__outcomePri__68BD7F23]  DEFAULT ((2)) FOR [outcomePrimario]
GO
ALTER TABLE [dbo].[ELMAH_Error] ADD  CONSTRAINT [DF_ELMAH_Error_ErrorId]  DEFAULT (newid()) FOR [ErrorId]
GO
ALTER TABLE [dbo].[EmergenzeLog] ADD  CONSTRAINT [DF_emergenzeLog_dataRegistrazione]  DEFAULT (getdate()) FOR [dataRegistrazione]
GO
ALTER TABLE [dbo].[EmergenzeLog] ADD  CONSTRAINT [DF_EmergenzeLog_ricercaCodTevere]  DEFAULT ('-') FOR [ricerca]
GO
ALTER TABLE [dbo].[EmergenzeLog] ADD  CONSTRAINT [DF_EmergenzeLog_adminChecked]  DEFAULT ((0)) FOR [adminChecked]
GO
ALTER TABLE [dbo].[KitRandomizzazione] ADD  CONSTRAINT [DF_KitRandomizzazione_Resi]  DEFAULT ((0)) FOR [Reso]
GO
ALTER TABLE [dbo].[MEDAS] ADD  CONSTRAINT [DF_MEDAS_d01]  DEFAULT ((0)) FOR [d01]
GO
ALTER TABLE [dbo].[StileDiVita] ADD  CONSTRAINT [DF_StileDiVita_mPreoccupazione]  DEFAULT ((0)) FOR [mPreoccupazione]
GO
ALTER TABLE [dbo].[StileDiVita] ADD  CONSTRAINT [DF_StileDiVita_mRicerca]  DEFAULT ((0)) FOR [mRicerca]
GO
ALTER TABLE [dbo].[StileDiVita] ADD  CONSTRAINT [DF_StileDiVita_mStile]  DEFAULT ((0)) FOR [mStile]
GO
ALTER TABLE [dbo].[StileDiVita] ADD  CONSTRAINT [DF_StileDiVita_mAltro]  DEFAULT ((0)) FOR [mAltro]
GO
ALTER TABLE [dbo].[StileDiVita] ADD  CONSTRAINT [DF_StileDiVita_peTiroide]  DEFAULT ((0)) FOR [peTiroide]
GO
ALTER TABLE [dbo].[StileDiVita] ADD  CONSTRAINT [DF_StileDiVita_peIpofisi]  DEFAULT ((0)) FOR [peIpofisi]
GO
ALTER TABLE [dbo].[StileDiVita] ADD  CONSTRAINT [DF_StileDiVita_pmeSurrene]  DEFAULT ((0)) FOR [peSurrene]
GO
ALTER TABLE [dbo].[StileDiVita] ADD  CONSTRAINT [DF_StileDiVita_peAltre]  DEFAULT ((0)) FOR [peAltre]
GO
ALTER TABLE [dbo].[StileDiVita] ADD  CONSTRAINT [DF_StileDiVita_pmUricemia]  DEFAULT ((0)) FOR [pmUricemia]
GO
ALTER TABLE [dbo].[StileDiVita] ADD  CONSTRAINT [DF_StileDiVita_menopausa]  DEFAULT ((0)) FOR [menopausa]
GO
ALTER TABLE [dbo].[StileDiVita] ADD  CONSTRAINT [DF_StileDiVita_mestruazioniDataUltimaNsNr]  DEFAULT ((0)) FOR [mestruazioniDataUltimaNsNr]
GO
ALTER TABLE [dbo].[ValutazioneMetformina] ADD  CONSTRAINT [DF_ValutazioneMetformina_effettiCollaterali]  DEFAULT ((0)) FOR [effettiCollaterali]
GO
ALTER TABLE [dbo].[AE]  WITH CHECK ADD  CONSTRAINT [FK_AE_Anagrafica] FOREIGN KEY([idPaziente])
REFERENCES [dbo].[Anagrafica] ([idPaziente])
GO
ALTER TABLE [dbo].[AE] CHECK CONSTRAINT [FK_AE_Anagrafica]
GO
ALTER TABLE [dbo].[AEDettaglio]  WITH CHECK ADD  CONSTRAINT [FK_AEDettaglio_AE] FOREIGN KEY([idAE])
REFERENCES [dbo].[AE] ([idAE])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AEDettaglio] CHECK CONSTRAINT [FK_AEDettaglio_AE]
GO
ALTER TABLE [dbo].[AEDettaglio]  WITH CHECK ADD  CONSTRAINT [FK_AEDettaglio_LUAE_Grado] FOREIGN KEY([serietaGrado])
REFERENCES [dbo].[LUAE_Grado] ([idAEGrado])
GO
ALTER TABLE [dbo].[AEDettaglio] CHECK CONSTRAINT [FK_AEDettaglio_LUAE_Grado]
GO
ALTER TABLE [dbo].[AEDettaglio]  WITH CHECK ADD  CONSTRAINT [FK_AEDettaglio_LUAE_Outcome] FOREIGN KEY([outcome])
REFERENCES [dbo].[LUAE_Outcome] ([idAEOutcome])
GO
ALTER TABLE [dbo].[AEDettaglio] CHECK CONSTRAINT [FK_AEDettaglio_LUAE_Outcome]
GO
ALTER TABLE [dbo].[AEDettaglio]  WITH CHECK ADD  CONSTRAINT [FK_AEDettaglio_LUAE_TipoEvento] FOREIGN KEY([tipoEvento])
REFERENCES [dbo].[LUAE_TipoEvento] ([idAETipoEvento])
GO
ALTER TABLE [dbo].[AEDettaglio] CHECK CONSTRAINT [FK_AEDettaglio_LUAE_TipoEvento]
GO
ALTER TABLE [dbo].[Anagrafica]  WITH CHECK ADD  CONSTRAINT [FK_Anagrafica_Comuni] FOREIGN KEY([comune], [provincia])
REFERENCES [dbo].[Comuni] ([CodiceComune], [ProvinciaSigla])
GO
ALTER TABLE [dbo].[Anagrafica] CHECK CONSTRAINT [FK_Anagrafica_Comuni]
GO
ALTER TABLE [dbo].[Anagrafica]  WITH CHECK ADD  CONSTRAINT [FK_Anagrafica_LUIParentela] FOREIGN KEY([parentela])
REFERENCES [dbo].[LUIParentela] ([idParentela])
GO
ALTER TABLE [dbo].[Anagrafica] CHECK CONSTRAINT [FK_Anagrafica_LUIParentela]
GO
ALTER TABLE [dbo].[Anagrafica]  WITH CHECK ADD  CONSTRAINT [FK_Anagrafica_LUIstruzione] FOREIGN KEY([istruzione])
REFERENCES [dbo].[LUIstruzione] ([idIstruzione])
GO
ALTER TABLE [dbo].[Anagrafica] CHECK CONSTRAINT [FK_Anagrafica_LUIstruzione]
GO
ALTER TABLE [dbo].[Anagrafica]  WITH CHECK ADD  CONSTRAINT [FK_Anagrafica_LUProfessione] FOREIGN KEY([professione])
REFERENCES [dbo].[LUProfessione] ([idProfessione])
GO
ALTER TABLE [dbo].[Anagrafica] CHECK CONSTRAINT [FK_Anagrafica_LUProfessione]
GO
ALTER TABLE [dbo].[Anagrafica]  WITH CHECK ADD  CONSTRAINT [FK_Anagrafica_LUStatoCivile] FOREIGN KEY([statocivile])
REFERENCES [dbo].[LUStatoCivile] ([idStatoCivile])
GO
ALTER TABLE [dbo].[Anagrafica] CHECK CONSTRAINT [FK_Anagrafica_LUStatoCivile]
GO
ALTER TABLE [dbo].[Antropometria]  WITH CHECK ADD  CONSTRAINT [FK_Antropometria_StatiRegistro] FOREIGN KEY([idStatoRegistro])
REFERENCES [dbo].[StatiRegistro] ([idStatoRegistro])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Antropometria] CHECK CONSTRAINT [FK_Antropometria_StatiRegistro]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AssegnazioneFarmaco]  WITH CHECK ADD  CONSTRAINT [FK_AssegnazioneFarmaco_AssegnazioniRegistro] FOREIGN KEY([idAssegnazioneRegistro])
REFERENCES [dbo].[AssegnazioniRegistro] ([idAssegnazioneRegistro])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AssegnazioneFarmaco] CHECK CONSTRAINT [FK_AssegnazioneFarmaco_AssegnazioniRegistro]
GO
ALTER TABLE [dbo].[AssegnazioniRegistro]  WITH CHECK ADD  CONSTRAINT [FK_AssegnazioniRegistro_Anagrafica] FOREIGN KEY([idPaziente])
REFERENCES [dbo].[Anagrafica] ([idPaziente])
GO
ALTER TABLE [dbo].[AssegnazioniRegistro] CHECK CONSTRAINT [FK_AssegnazioniRegistro_Anagrafica]
GO
ALTER TABLE [dbo].[AssegnazioniRegistro]  WITH CHECK ADD  CONSTRAINT [FK_AssegnzioniRegistro_AssegnazioniElenco] FOREIGN KEY([idAssegnazioneElenco])
REFERENCES [dbo].[AssegnazioniElenco] ([idAssegnazioneElenco])
GO
ALTER TABLE [dbo].[AssegnazioniRegistro] CHECK CONSTRAINT [FK_AssegnzioniRegistro_AssegnazioniElenco]
GO
ALTER TABLE [dbo].[AttivitaFisica]  WITH CHECK ADD  CONSTRAINT [FK_AttivitaFisica_StatiRegistro] FOREIGN KEY([idStatoRegistro])
REFERENCES [dbo].[StatiRegistro] ([idStatoRegistro])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AttivitaFisica] CHECK CONSTRAINT [FK_AttivitaFisica_StatiRegistro]
GO
ALTER TABLE [dbo].[DiarioDieta24]  WITH CHECK ADD  CONSTRAINT [FK_DiarioDieta24_StatiRegistro] FOREIGN KEY([idStatoRegistro])
REFERENCES [dbo].[StatiRegistro] ([idStatoRegistro])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DiarioDieta24] CHECK CONSTRAINT [FK_DiarioDieta24_StatiRegistro]
GO
ALTER TABLE [dbo].[Drop]  WITH CHECK ADD  CONSTRAINT [FK_Drop_LUDropMotivazioni] FOREIGN KEY([idMotivazione])
REFERENCES [dbo].[LUDropMotivazioni] ([idMotivazione])
GO
ALTER TABLE [dbo].[Drop] CHECK CONSTRAINT [FK_Drop_LUDropMotivazioni]
GO
ALTER TABLE [dbo].[Drop]  WITH CHECK ADD  CONSTRAINT [FK_Drop_StatiRegistro] FOREIGN KEY([idStatoRegistro])
REFERENCES [dbo].[StatiRegistro] ([idStatoRegistro])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Drop] CHECK CONSTRAINT [FK_Drop_StatiRegistro]
GO
ALTER TABLE [dbo].[KitFlaconiAssegnazione]  WITH CHECK ADD  CONSTRAINT [FK_KitFlaconiAssegnazione_Anagrafica] FOREIGN KEY([idPaziente])
REFERENCES [dbo].[Anagrafica] ([idPaziente])
GO
ALTER TABLE [dbo].[KitFlaconiAssegnazione] CHECK CONSTRAINT [FK_KitFlaconiAssegnazione_Anagrafica]
GO
ALTER TABLE [dbo].[KitFlaconiAssegnazione]  WITH CHECK ADD  CONSTRAINT [FK_KitFlaconiAssegnazione_AssegnazioniElenco] FOREIGN KEY([idAssegnazioneElenco])
REFERENCES [dbo].[AssegnazioniElenco] ([idAssegnazioneElenco])
GO
ALTER TABLE [dbo].[KitFlaconiAssegnazione] CHECK CONSTRAINT [FK_KitFlaconiAssegnazione_AssegnazioniElenco]
GO
ALTER TABLE [dbo].[KitFlaconiAssegnazione]  WITH CHECK ADD  CONSTRAINT [FK_KitFlaconiAssegnazione_KitRandomizzazioneMiPharm] FOREIGN KEY([Kit])
REFERENCES [dbo].[KitRandomizzazione] ([Kit])
GO
ALTER TABLE [dbo].[KitFlaconiAssegnazione] CHECK CONSTRAINT [FK_KitFlaconiAssegnazione_KitRandomizzazioneMiPharm]
GO
ALTER TABLE [dbo].[MEDAS]  WITH CHECK ADD  CONSTRAINT [FK_Medas_StatiRegistro] FOREIGN KEY([idStatoRegistro])
REFERENCES [dbo].[StatiRegistro] ([idStatoRegistro])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MEDAS] CHECK CONSTRAINT [FK_Medas_StatiRegistro]
GO
ALTER TABLE [dbo].[Prelievo]  WITH CHECK ADD  CONSTRAINT [FK_Prelievo_StatiRegistro] FOREIGN KEY([idStatoRegistro])
REFERENCES [dbo].[StatiRegistro] ([idStatoRegistro])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Prelievo] CHECK CONSTRAINT [FK_Prelievo_StatiRegistro]
GO
ALTER TABLE [dbo].[SAE]  WITH CHECK ADD  CONSTRAINT [FK_SAE_Anagrafica] FOREIGN KEY([idPaziente])
REFERENCES [dbo].[Anagrafica] ([idPaziente])
GO
ALTER TABLE [dbo].[SAE] CHECK CONSTRAINT [FK_SAE_Anagrafica]
GO
ALTER TABLE [dbo].[StatiRegistro]  WITH CHECK ADD  CONSTRAINT [FK_StatiRegistro_Anagrafica] FOREIGN KEY([idPaziente])
REFERENCES [dbo].[Anagrafica] ([idPaziente])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StatiRegistro] CHECK CONSTRAINT [FK_StatiRegistro_Anagrafica]
GO
ALTER TABLE [dbo].[StatiRegistro]  WITH CHECK ADD  CONSTRAINT [FK_StatiRegistro_StatiElenco] FOREIGN KEY([idStato])
REFERENCES [dbo].[StatiElenco] ([idStato])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[StatiRegistro] CHECK CONSTRAINT [FK_StatiRegistro_StatiElenco]
GO
ALTER TABLE [dbo].[StileDiVita]  WITH CHECK ADD  CONSTRAINT [FK_StileDiVita_StatiRegistro] FOREIGN KEY([idStatoRegistro])
REFERENCES [dbo].[StatiRegistro] ([idStatoRegistro])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StileDiVita] CHECK CONSTRAINT [FK_StileDiVita_StatiRegistro]
GO
ALTER TABLE [dbo].[Trattamenti]  WITH CHECK ADD  CONSTRAINT [FK_Trattamenti_StatiRegistro] FOREIGN KEY([idStatoRegistro])
REFERENCES [dbo].[StatiRegistro] ([idStatoRegistro])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Trattamenti] CHECK CONSTRAINT [FK_Trattamenti_StatiRegistro]
GO
ALTER TABLE [dbo].[TrattamentiDettaglio]  WITH CHECK ADD  CONSTRAINT [FK_TrattamentiDettaglio_LUTipoTrattamento] FOREIGN KEY([tipoTrattamento])
REFERENCES [dbo].[LUTipoTrattamento] ([idTipoTrattamento])
GO
ALTER TABLE [dbo].[TrattamentiDettaglio] CHECK CONSTRAINT [FK_TrattamentiDettaglio_LUTipoTrattamento]
GO
ALTER TABLE [dbo].[TrattamentiDettaglio]  WITH CHECK ADD  CONSTRAINT [FK_TrattamentiDettaglio_Trattamenti] FOREIGN KEY([idStatoRegistro])
REFERENCES [dbo].[Trattamenti] ([idStatoRegistro])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TrattamentiDettaglio] CHECK CONSTRAINT [FK_TrattamentiDettaglio_Trattamenti]
GO
ALTER TABLE [dbo].[ValutazioneMetformina]  WITH CHECK ADD  CONSTRAINT [FK_ValuazioneMeformina_StatiRegistro] FOREIGN KEY([idStatoRegistro])
REFERENCES [dbo].[StatiRegistro] ([idStatoRegistro])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ValutazioneMetformina] CHECK CONSTRAINT [FK_ValuazioneMeformina_StatiRegistro]
GO
/****** Object:  StoredProcedure [dbo].[sp_AssegnazioniPostRandomizzazione]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===========================================================================================
-- Author:		Giuseppe Fornaciari
-- Create date: 21/03/2015
-- Description:	Assegnazione flacone Postrandomizzazione con gestione dosaggio
-- Modifica:	09/04/2016 distribuzione con copertura data scandenza
-- ===========================================================================================
CREATE PROCEDURE [dbo].[sp_AssegnazioniPostRandomizzazione]
 @idPaziente as int
,@utente as varchar(50)
,@idAssegnazioneElenco as int
,@numFlaconi as int
,@dataConsegna as date
,@dosaggio as int /*1=pieno; 0=mezzo*/
AS
DECLARE @kit nvarchar(7)
DECLARE @randomizzazioneTrattamento varbinary(128)
DECLARE @contaIntervento as int
DECLARE @contaControllo as int
DECLARE @dataCopertura as date

DECLARE @c int
SET @c=1

	/*controlla che il partecipante SIA già stato randomizzato*/
	if(SELECT COUNT(idPaziente) 
	   FROM Anagrafica 
	   WHERE idPaziente=@idPaziente 
	   AND randomizzazioneTrattamento IS NULL) = 1
	BEGIN
		RETURN 
	END 
	/*Assegnazione in transazione*/
	BEGIN TRAN Randomizza
	    /*1 recupera codice centro*/
		SELECT @randomizzazioneTrattamento=randomizzazioneTrattamento FROM Anagrafica WHERE idPaziente=@idPaziente
		IF (@@ERROR <> 0) GOTO TRANS_FALLITA
		/*2 assegna data copertura in base a dosaggio*/
		IF(@dosaggio=1)
			BEGIN
				SET @dataCopertura=DATEADD (MONTH , 1 , @dataConsegna ) -- flacone per 1 mese
			END
		ELSE
			BEGIN
				SET @dataCopertura=DATEADD (MONTH , 2 , @dataConsegna ) -- flacone per 2 mesi
			END
		IF (@@ERROR <> 0) GOTO TRANS_FALLITA
		/*3 Assegna flaconi dal dosaggio selezionando i non assegnati delle stessa tipologia */
		WHILE @c <= @numFlaconi
		BEGIN
			SELECT TOP 1 @kit=kit
			FROM KitRandomizzazione
			WHERE Reso = 0
			AND Lotto <> '-'
			AND Kit NOT IN (SELECT Kit FROM KitFlaconiAssegnazione)
			AND CONVERT(varchar, DecryptByPassPhrase('testAUDIT', TreatmentGroupDescription)) = CONVERT(varchar, DecryptByPassPhrase('testAUDIT', @randomizzazioneTrattamento)) 
			AND Contenuto='850ml 62 pillole'
			AND ScadenzaFarmaco> @dataCopertura
			ORDER BY kit ASC
			IF (@@ERROR <> 0) GOTO TRANS_FALLITA
			/*3.1 inserisce assegnazione*/
			INSERT INTO KitFlaconiAssegnazione (kit,utente,dataAssegnazione,idPaziente,idAssegnazioneElenco)
			VALUES(@kit,@utente,getdate(),@idPaziente,@idAssegnazioneElenco)
			IF (@@ERROR <> 0) GOTO TRANS_FALLITA
			/*3.2 aggiorna data copertura in base a dosaggio e avanza contatore*/
			IF(@dosaggio=1) 
				BEGIN
	    			SET @dataCopertura=DATEADD (MONTH , 1 , @dataCopertura ) -- 1 flacone per 1 mese
	    		END
			ELSE 
				BEGIN
	    			SET @dataCopertura=DATEADD (MONTH , 2 , @dataCopertura ) -- 1 flacone per 2 mesi
	    		END
			SET @c=@c+1
		END
	COMMIT TRAN Randomizza
	GOTO FINE
			
TRANS_FALLITA:
ROLLBACK TRAN Randomizza
RETURN

FINE:
RETURN
GO
/****** Object:  StoredProcedure [dbo].[sp_AssegnazioniPostRandomizzazioneDateScadenza]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===========================================================================================
-- Author:		Giuseppe Fornaciari
-- Create date: 25/03/2015
-- Description:	Recupera date scedenza all'assegnazione dei farmaci
-- ===========================================================================================
CREATE PROCEDURE [dbo].[sp_AssegnazioniPostRandomizzazioneDateScadenza]
 @idPaziente as int
,@numFlaconi as int
,@dataConsegna as date
,@dosaggio as int /*1=pieno; 0=mezzo*/
AS
DECLARE @scadenze as NVARCHAR(500)
DECLARE @c as int
DECLARE @currentKit as varchar(10)
DECLARE @serieKit as NVARCHAR(500)
DECLARE @dataCopertura as date
DECLARE @sql as NVARCHAR(MAX)

SET @c=1
SET @serieKit=''
SET @currentKit=''

/*A CALCOLA DATA COPERTURA*/
IF(@dosaggio=1)
	BEGIN
		SET @dataCopertura=DATEADD (MONTH , 1 , @dataConsegna ) -- flacone per 1 mese
	END
ELSE
	BEGIN
		SET @dataCopertura=DATEADD (MONTH , 2 , @dataConsegna ) -- flacone per 2 mesi
	END
	/*B ESTRAE FLACONI*/
	WHILE @c <= @numFlaconi
		BEGIN
			-- 1  Selezione flacone
			SELECT TOP 1 @currentKit=kit
			FROM KitRandomizzazione
			WHERE Reso = 0
			AND Lotto <> '-'
			AND Kit NOT IN (SELECT Kit FROM KitFlaconiAssegnazione)
			AND CONVERT(varchar, DecryptByPassPhrase('testAUDIT', TreatmentGroupDescription)) = CONVERT(varchar, DecryptByPassPhrase('testAUDIT', (SELECT randomizzazioneTrattamento FROM Anagrafica WHERE idPaziente=@idPaziente))) 
			AND Contenuto='850ml 62 pillole'
			AND kit>@currentKit
			AND ScadenzaFarmaco> @dataCopertura
			ORDER BY kit ASC

			-- 2 aggiorna dataCopertura
			IF(@dosaggio=1)
	    		-- 1 flacone per 1 mese
	    		BEGIN
	    			SET @dataCopertura=DATEADD (MONTH , 1 , @dataCopertura ) 
	    		END
			ELSE
	    		-- 1 flacone per 2 mesi
	    		BEGIN
	    			SET @dataCopertura=DATEADD (MONTH , 2 , @dataCopertura )
	    		END
			---3 compone stringa selezione
			IF(@serieKit='')
			BEGIN
				SET @serieKit=''''+@currentKit+''''
			END
			ELSE 
			BEGIN
				SET @serieKit=@serieKit+','+''''+@currentKit+''''
			END
			SET @c=@c+1
		

		END

Set @sql='SELECT kit, ScadenzaFarmaco FROM KitRandomizzazione WHERE kit IN ('+@serieKit+')'
--PRINT @sql
exec sp_executesql @sql, @scadenze OUTPUT

GO
/****** Object:  StoredProcedure [dbo].[sp_CorrezioneProtocollo]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Author:		Giuseppe Fornaciari
-- Create date: 31/03/2015
-- Description:	SOLO EMERGENZA. Rompe il cieco per un paziente alla volta ricercato per
-- 1 idPaziente
-- ==========================================================================================
CREATE PROCEDURE [dbo].[sp_CorrezioneProtocollo]
	 @idPaziente as int
AS
BEGIN
	--- 1a INSERISCE ANTROPOMETRIA
	INSERT INTO [dbo].[Antropometria]
			   ([idStatoRegistro]
			   ,[dataInserimento]
			   ,[userName]
			   ,[data]
			   ,[altezza]
			   ,[peso]
			   ,[circonferenzaVita]
			   ,[circonferenzaFianchi]
			   ,[pressioneMax]
			   ,[pressioneMin]
			   ,[pulsazioni]
			   ,[terapiaIpertensione]
			   ,[terapiaIpercolesterolemia]
			   ,[terapiaIpertrigliceridemia]
			   ,[cardioaspirina]
			   ,[note])
	SELECT     (SELECT TOP 1 idStatoregistro FROM StatiRegistro WHERE idPaziente=@idPaziente order by idStato DESC)
			   ,GETDATE()
			   ,[userName]
			   ,[data]
			   ,[altezza]
			   ,[peso]
			   ,[circonferenzaVita]
			   ,[circonferenzaFianchi]
			   ,[pressioneMax]
			   ,[pressioneMin]
			   ,[pulsazioni]
			   ,[terapiaIpertensione]
			   ,[terapiaIpercolesterolemia]
			   ,[terapiaIpertrigliceridemia]
			   ,[cardioaspirina]
			   ,[note] 
	 FROM  RecuperareCambioProtocollo_Antropometria
	 WHERE idStatoRegistro = 
	 (
		SELECT idStatoRegistro 
		FROM RecuperareCambioProtocollo_StatiRegisto WHERE idPaziente=@idPaziente AND idStato=12
	  )
	--- 1b Aggiorna stato e Aggiunge Prelievo
	UPDATE StatiRegistro SET datachiusura=getdate(), completamento=1 WHERE idStatoRegistro = (SELECT TOP 1 idStatoRegistro FROM StatiRegistro WHERE idPaziente=@idPaziente order by idStato DESC)
	INSERT INTO [dbo].[StatiRegistro]
			   ([idPaziente]
			   ,[idStato]
			   ,[DataApertura]
			   ,[DataChiusura]
			   ,[Completamento])
		 VALUES
			   (@idPaziente
			   ,15
			   ,GETDATE()
			   ,null
			   ,0)
	--- 2a INSERISCE PRELIEVO
	INSERT INTO [dbo].[Prelievo]
			   ([idStatoRegistro]
			   ,[dataInserimento]
			   ,[userName]
			   ,[data]
			   ,[leucociti]
			   ,[eritrociti]
			   ,[emoglobina]
			   ,[ematocrito]
			   ,[MCV]
			   ,[MCH]
			   ,[MCHC]
			   ,[RDW]
			   ,[piastrine]
			   ,[MPV]
			   ,[neutrofili_pc]
			   ,[neutrofili_nm]
			   ,[linfociti_pc]
			   ,[linfociti_nm]
			   ,[monociti_pc]
			   ,[monociti_nm]
			   ,[eosinofili_pc]
			   ,[eosinofili_nm]
			   ,[basofili_pc]
			   ,[basofili_nm]
			   ,[grandicellule_pc]
			   ,[grandicellule_nm]
			   ,[glicemia]
			   ,[creatininemia]
			   ,[transaminasiGOT_AST]
			   ,[transaminasiGPL_ALT]
			   ,[gammaGlutammil]
			   ,[colesterolemia]
			   ,[HDL]
			   ,[LDL]
			   ,[trigliceridi]
			   ,[EGFR]
			   ,[urinePh]
			   ,[urineLeucociti]
			   ,[urineNitriti]
			   ,[urineAlbumina]
			   ,[urineGlucosio]
			   ,[urineChetoni]
			   ,[urineUrobinologico]
			   ,[urineBilirubina]
			   ,[urineEmoglobina]
			   ,[urinePesoSpecifico]
			   ,[urineAspetto]
			   ,[urineColore]
			   ,[urineEsameSedimento]
			   ,[note])
	SELECT (SELECT TOP 1 idStatoregistro FROM StatiRegistro WHERE idPaziente=@idPaziente order by idStato DESC)
		  ,GETDATE()
		  ,[userName]
		  ,[data]
		  ,[leucociti]
		  ,[eritrociti]
		  ,[emoglobina]
		  ,[ematocrito]
		  ,[MCV]
		  ,[MCH]
		  ,[MCHC]
		  ,[RDW]
		  ,[piastrine]
		  ,[MPV]
		  ,[neutrofili_pc]
		  ,[neutrofili_nm]
		  ,[linfociti_pc]
		  ,[linfociti_nm]
		  ,[monociti_pc]
		  ,[monociti_nm]
		  ,[eosinofili_pc]
		  ,[eosinofili_nm]
		  ,[basofili_pc]
		  ,[basofili_nm]
		  ,[grandicellule_pc]
		  ,[grandicellule_nm]
		  ,[glicemia]
		  ,[creatininemia]
		  ,[transaminasiGOT_AST]
		  ,[transaminasiGPL_ALT]
		  ,[gammaGlutammil]
		  ,[colesterolemia]
		  ,[HDL]
		  ,[LDL]
		  ,[trigliceridi]
		  ,[EGFR]
		  ,[urinePh]
		  ,[urineLeucociti]
		  ,[urineNitriti]
		  ,[urineAlbumina]
		  ,[urineGlucosio]
		  ,[urineChetoni]
		  ,[urineUrobinologico]
		  ,[urineBilirubina]
		  ,[urineEmoglobina]
		  ,[urinePesoSpecifico]
		  ,[urineAspetto]
		  ,[urineColore]
		  ,[urineEsameSedimento]
		  ,[note]
	 FROM  RecuperareCambioProtocollo_Prelievo
	 WHERE idStatoRegistro = 
	 (
		SELECT idStatoRegistro 
		FROM RecuperareCambioProtocollo_StatiRegisto WHERE idPaziente=@idPaziente AND idStato=13
	  )
	--- 2b Aggiorna stato e Aggiunge Trattamento
	UPDATE StatiRegistro SET datachiusura=getdate(), completamento=1 WHERE idStatoRegistro = (SELECT TOP 1 idStatoRegistro FROM StatiRegistro WHERE idPaziente=@idPaziente order by idStato DESC)
	INSERT INTO [dbo].[StatiRegistro]
			   ([idPaziente]
			   ,[idStato]
			   ,[DataApertura]
			   ,[DataChiusura]
			   ,[Completamento])
		 VALUES
			   (@idPaziente
			   ,16
			   ,GETDATE()
			   ,null
			   ,0)
	--- 3a INSERISCE TRATTAMENTO
	INSERT INTO [dbo].[Trattamenti]
			   ([idStatoRegistro]
			   ,[dataInserimento]
			   ,[userName]
			   ,[data])
	SELECT (SELECT TOP 1 idStatoregistro FROM StatiRegistro WHERE idPaziente=@idPaziente order by idStato DESC)
		  ,GETDATE()
		  ,[userName]
		  ,[data]
	 FROM  RecuperareCambioProtocollo_Trattamenti
	 WHERE idStatoRegistro = 
	 (
		SELECT idStatoRegistro 
		FROM RecuperareCambioProtocollo_StatiRegisto WHERE idPaziente=@idPaziente AND idStato=14
	  )
	--- 3b INSERISCE TRATTAMENTO RETTAGLIO
	INSERT INTO [dbo].[TrattamentiDettaglio]
			   ([idStatoRegistro]
			   ,[tipoTrattamento]
			   ,[tipoTrattamentoAltro]
			   ,[trattamento]
			   ,[doseGiornaliera]
			   ,[motivo]
			   ,[durata])
	SELECT 
		   (SELECT TOP 1 idStatoregistro FROM StatiRegistro WHERE idPaziente=@idPaziente order by idStato DESC)
		  ,[tipoTrattamento]
		  ,[tipoTrattamentoAltro]
		  ,[trattamento]
		  ,[doseGiornaliera]
		  ,[motivo]
		  ,[durata]
	 FROM  RecuperareCambioProtocollo_TrattamentiDettaglio
	 WHERE idStatoRegistro = 
	 (
		SELECT idStatoRegistro 
		FROM RecuperareCambioProtocollo_StatiRegisto WHERE idPaziente=@idPaziente AND idStato=14
	  )
	--- 3c Aggiorna stato e Aggiunge corrente
	UPDATE StatiRegistro SET datachiusura=getdate(), completamento=1 WHERE idStatoRegistro = (SELECT TOP 1 idStatoRegistro FROM StatiRegistro WHERE idPaziente=@idPaziente order by idStato DESC)
	INSERT INTO [dbo].[StatiRegistro]
			   ([idPaziente]
			   ,[idStato]
			   ,[DataApertura]
			   ,[DataChiusura]
			   ,[Completamento])
		 VALUES
			   (@idPaziente
			   ,17
			   ,GETDATE()
			   ,null
			   ,0)

END
GO
/****** Object:  StoredProcedure [dbo].[sp_disponibilitaMinima]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_disponibilitaMinima] 
@flaconi int OUTPUT  
AS
BEGIN

	SET NOCOUNT ON;
	SELECT @flaconi=count(*)
  FROM [MeMeMe].[dbo].[KitRandomizzazione]
  WHERE lotto is not null
  and reso=0
  and kit not in (select kit FROM [MeMeMe].[dbo].[KitFlaconiAssegnazione])
  GROUP by CONVERT(char(1), DecryptByPassPhrase('testAUDIT',TreatmentGroupDescription))

  return @flaconi

END
GO
/****** Object:  StoredProcedure [dbo].[sp_ElencoPrelievi]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===========================================================================================
-- Author:		Giuseppe Fornaciari
-- Create date: 08/02/2018
-- Description:	Lista pazienti Tevere/MeMeMe per data prelievo
-- ===========================================================================================
CREATE PROCEDURE [dbo].[sp_ElencoPrelievi]

 @dateDa as datetime = null
,@dateA as datetime =null

AS
IF @dateDa IS NULL AND @dateA IS NULL
BEGIN
	SELECT * FROM
	(
	---- tevere
	SELECT 'Tevere' as progetto, dataMisurazione as dataPrelievo, P.idTevere as idPaziente,nome,cognome
	,idCentro as Dieta
	,telefonocasa,telefonolavoro,telefonocellulare
	FROM [progettotevere].[dbo].[SchedaFPAntropometriaSangueUrine] FPPSA
	INNER JOIN [progettotevere].[dbo].[Partecipanti] P ON FPPSA.idTevere=p.idTevere
	WHERE p.idTevere NOT IN (SELECT idTevere FROM [progettotevere].[dbo].[FormR])
	UNION ALL
	---- mememe
	SELECT 'MeMeMe' as progetto, P.[data] as dataPrelievo, a.idPaziente as idPaziente, Nome, cognome  
	,CASE WHEN randomizzazioneDieta='1' THEN 'Blu' WHEN randomizzazioneDieta='2' THEN 'Verde' END as Dieta
	,telefonofisso,telefonolavoro,telefonocellulare
	FROM [MeMeMe].[dbo].[Prelievo] P
	INNER JOIN [MeMeMe].[dbo].[StatiRegistro] SR ON p.idStatoRegistro=sr.idStatoRegistro
	INNER JOIN [MeMeMe].[dbo].[Anagrafica] A ON SR.idPaziente=A.idPaziente 
	WHERE a.idPaziente NOT IN (SELECT DISTINCT idPaziente FROM StatiRegistro INNER JOIN [DROP] on StatiRegistro.idStatoRegistro=[Drop].idStatoRegistro)
	) as PrelieviProgetti
	ORDER BY dataPrelievo DESC
END
ELSE
BEGIN
	SELECT * FROM
	(
		---- tevere
		SELECT 'Tevere' as progetto, dataMisurazione as dataPrelievo, P.idTevere as idPaziente,nome,cognome
		,idCentro as Dieta
		,telefonocasa,telefonolavoro,telefonocellulare
		FROM [progettotevere].[dbo].[SchedaFPAntropometriaSangueUrine] FPPSA
		INNER JOIN [progettotevere].[dbo].[Partecipanti] P ON FPPSA.idTevere=p.idTevere
		WHERE p.idTevere NOT IN (SELECT idTevere FROM [progettotevere].[dbo].[FormR])
		UNION ALL
		---- mememe
		SELECT 'MeMeMe' as progetto, P.[data] as dataPrelievo, a.idPaziente as idPaziente, Nome, cognome  
		,CASE WHEN randomizzazioneDieta='1' THEN 'Blu' WHEN randomizzazioneDieta='2' THEN 'Verde' END as Dieta
		,telefonofisso,telefonolavoro,telefonocellulare
		FROM [MeMeMe].[dbo].[Prelievo] P
		INNER JOIN [MeMeMe].[dbo].[StatiRegistro] SR ON p.idStatoRegistro=sr.idStatoRegistro
		INNER JOIN [MeMeMe].[dbo].[Anagrafica] A ON SR.idPaziente=A.idPaziente 
		WHERE a.idPaziente NOT IN (SELECT DISTINCT idPaziente FROM StatiRegistro INNER JOIN [DROP] on StatiRegistro.idStatoRegistro=[Drop].idStatoRegistro)
	) as PrelieviProgetti
	WHERE dataPrelievo is not null AND dataPrelievo between @dateDa and @dateA
	ORDER BY dataPrelievo DESC
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EmergenzaRotturaCieco]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Author:		Giuseppe Fornaciari
-- Create date: 31/03/2015
-- Description:	SOLO EMERGENZA. Rompe il cieco per un paziente alla volta ricercato per
-- 1 idPaziente
-- ==========================================================================================
CREATE PROCEDURE [dbo].[sp_EmergenzaRotturaCieco]
	 @idPaziente as int
	,@randomizzazione varchar(50) OUTPUT
AS
BEGIN
	/*RICERCA*/
	SELECT 
	@randomizzazione=isNull(CONVERT(varchar, DecryptByPassPhrase('testAUDIT', [randomizzazioneTrattamento])),'paziente NON RANDOMIZZATO!')
	FROM Anagrafica 
	WHERE idPaziente = @idPaziente
	RETURN 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RandomizzazioneFarmaco]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Author:		Giuseppe Fornaciari
-- Create date: 24/02/2015
-- Description:	Randomizza paziente. Regole bilanciamento per sesso e età, il bilanciamento
--              è corretto sui DROP allo scopo di avere sempre gruppi bilanciati.
--				1 assegnazione in anagrafica braccio e data randomizzazione
--              2 inserimento flacone nel registro delle assegnazioni
-- modifica dal 26/4/2016 copertura 2 mesi flacone di randomizzazione SENZA ECCEZIONI
-- ==========================================================================================
CREATE PROCEDURE [dbo].[sp_RandomizzazioneFarmaco]
	 @idPaziente as int
	,@idAssegnazioneElenco as int
	,@utente as varchar(50)
AS

DECLARE @randomizzazioneTrattamento as varbinary(128)
DECLARE @sesso as char(1)
DECLARE @datanascita as datetime
DECLARE @contaM as int
DECLARE @contaP as int
DECLARE @kit nvarchar(6)

BEGIN
	SET NOCOUNT ON;
	/*Parametri controllo e di strato*/
	SELECT @sesso=sesso,@datanascita=dataNascita,@randomizzazioneTrattamento=randomizzazioneTrattamento 
	FROM Anagrafica WHERE Anagrafica.IDPAziente=@IdPaziente
	
	/*Conteggi strato*/
	IF DATEDIFF(year,@datanascita,getdate())>67
		BEGIN
			SELECT @contaM=[M],@contaP=[P]
			FROM 
			(SELECT CONVERT(char(1), DecryptByPassPhrase('testAUDIT',randomizzazioneTrattamento)) as tipo
			FROM Anagrafica 
			WHERE sesso=@sesso
			AND DATEDIFF(year,DataNascita,getdate())>67		---- Correzione 2017/02/26
			---AND DATEDIFF(year,getdate(),DataNascita)>67	---- Errore calcolo età
			AND idPaziente NOT IN (SELECT idPaziente FROM  StatiRegistro WHERE idStato=99)
			) p
			PIVOT
			(
			COUNT (tipo)
			FOR tipo IN
			( [M], [P] )
			) AS pvt
		END	
	ELSE
		BEGIN
			SELECT @contaM=[M],@contaP=[P]
			FROM 
			(SELECT CONVERT(char(1), DecryptByPassPhrase('testAUDIT',randomizzazioneTrattamento)) as tipo
			FROM Anagrafica 
			WHERE sesso=@sesso
			AND DATEDIFF(year,DataNascita,getdate())<=67 	---- Correzione 2017/02/26
			---AND DATEDIFF(year,getdate(),DataNascita)<=67 ---- Errore calcolo età
			AND idPaziente NOT IN (SELECT idPaziente FROM  StatiRegistro WHERE idStato=99)
			) p
			PIVOT
			(
			COUNT (tipo)
			FOR tipo IN
			( [M], [P] )
			) AS pvt
		END	

		/*controlla che il partecipante non sia già stato randomizzato*/
		if(SELECT COUNT(idPaziente) FROM Anagrafica WHERE idPaziente=@idPaziente AND randomizzazioneTrattamento IS NOT NULL)= 1
		BEGIN
			RETURN 
		END 
		BEGIN TRAN Randomizza
			/*Se i due gruppi sono bilanciati randomizza scegliento primo elemento libero dalla lista KIT*/
			/*1 recupera primo id libero per centro*/
			IF @contaM=@contaP 
			BEGIN
				SELECT TOP 1 @kit=KR.kit,@randomizzazioneTrattamento=TreatmentGroupDescription 
				FROM KitRandomizzazione KR
				WHERE Kit NOT IN (SELECT Kit FROM KitFlaconiAssegnazione)
				AND Contenuto='850ml 62 pillole' 
				AND ScadenzaFarmaco>=dateadd(month,2 ,getdate())  -- COPERTURA 2 mesi
                AND Lotto <> '-'
				AND reso = 0
				ORDER BY KR.kit ASC
			END
			ELSE
			BEGIN 
				IF @contaM>@contaP 
				BEGIN
					SELECT TOP 1 @kit=KR.kit,@randomizzazioneTrattamento=TreatmentGroupDescription 
					FROM KitRandomizzazione KR
					WHERE CONVERT(char(1), DecryptByPassPhrase('testAUDIT',TreatmentGroupDescription))='P'
					AND Kit NOT IN (SELECT Kit FROM KitFlaconiAssegnazione)
					AND Contenuto='850ml 62 pillole' 
					AND ScadenzaFarmaco>=dateadd(month,2 ,getdate())  -- COPERTURA 2 mesi
                    AND Lotto <> '-'
					AND reso = 0
					ORDER BY KR.kit ASC
				END
				ELSE
				BEGIN
					SELECT TOP 1 @kit=KR.kit,@randomizzazioneTrattamento=TreatmentGroupDescription 
					FROM KitRandomizzazione KR
					WHERE CONVERT(char(1), DecryptByPassPhrase('testAUDIT',TreatmentGroupDescription))='M'
					AND Kit NOT IN (SELECT Kit FROM KitFlaconiAssegnazione)
					AND Contenuto='850ml 62 pillole' 
					AND ScadenzaFarmaco>=dateadd(month,2 ,getdate())  -- COPERTURA 2 mesi
                    AND Lotto <> '-'
					AND reso = 0
					ORDER BY KR.kit ASC
				END
			END
			IF (@@ERROR <> 0) GOTO TRANS_FALLITA
			/*2 inserisce nel registro assegnazioni*/
			INSERT INTO KitFlaconiAssegnazione (kit,utente,dataAssegnazione,idPaziente,idAssegnazioneElenco)
			VALUES(@kit,@utente,getdate(),@idPaziente,@idAssegnazioneElenco)
			IF (@@ERROR <> 0) GOTO TRANS_FALLITA
			/*3 imposta randomizzazione e data su Anagrafica*/
			UPDATE Anagrafica
			SET randomizzazioneTrattamento=@randomizzazioneTrattamento
			,dataRandomizzazioneTrattamento=GETDATE()
			WHERE idPaziente=@idPaziente
			IF (@@ERROR <> 0) GOTO TRANS_FALLITA
		COMMIT TRAN Randomizza
		GOTO FINE
			
	TRANS_FALLITA:
	ROLLBACK TRAN Randomizza
	RETURN

	FINE:
	RETURN

END
GO
/****** Object:  StoredProcedure [dbo].[sp_RandomizzazioneFarmacoSIMULAZIONE]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Author:		Giuseppe Fornaciari
-- Create date: 24/02/2015
-- Description:	Randomizza paziente. Regole bilanciamento per sesso e età, il bilanciamento
--              è corretto sui DROP allo scopo di avere sempre gruppi bilanciati.
--				1 assegnazione in anagrafica braccio e data randomizzazione
--              2 inserimento flacone nel registro delle assegnazioni
-- modifica dal 26/4/2016 copertura 2 mesi flacone di randomizzazione SENZA ECCEZIONI
-- ==========================================================================================
CREATE PROCEDURE [dbo].[sp_RandomizzazioneFarmacoSIMULAZIONE]
	 @idPaziente as int
	,@idAssegnazioneElenco as int
	,@utente as varchar(50)
AS

DECLARE @randomizzazioneTrattamento as varbinary(128)
DECLARE @sesso as char(1)
DECLARE @datanascita as datetime
DECLARE @data as datetime
DECLARE @contaM as int
DECLARE @contaP as int
DECLARE @kit nvarchar(6)

BEGIN
	SET NOCOUNT ON;
	/*Parametri controllo e di strato*/
	SELECT @sesso=sesso,@datanascita=dataNascita,@randomizzazioneTrattamento=randomizzazioneTrattamento 
	FROM _AnagraficaVerificaRandomiazzione WHERE IDPAziente=@IdPaziente
	/*Conteggi strato*/

	---IF DATEDIFF(year,@datanascita,getdate())>67
	IF DATEDIFF(year,@datanascita,getdate())>67
		BEGIN
			SELECT @contaM=[M],@contaP=[P]
			FROM 
			(
				SELECT CONVERT(char(1), DecryptByPassPhrase('testAUDIT',randomizzazioneTrattamento)) as tipo
				FROM _AnagraficaVerificaRandomiazzione 
				WHERE sesso=@sesso
				AND DATEDIFF(year,datanascita,getdate())>67 
				--AND dropOut=0
				--AND idPaziente NOT IN (SELECT idPaziente FROM  StatiRegistro WHERE idStato=99)
			) p
			PIVOT
			(
			COUNT (tipo)
			FOR tipo IN
			( [M], [P] )
			) AS pvt
		END	
	ELSE
		BEGIN
			SELECT @contaM=[M],@contaP=[P]
			FROM 
			(
				SELECT CONVERT(char(1), DecryptByPassPhrase('testAUDIT',randomizzazioneTrattamento)) as tipo
				FROM _AnagraficaVerificaRandomiazzione 
				WHERE sesso=@sesso
				AND DATEDIFF(year,DataNascita,getdate())<=67 
				---AND dropOut=0
				--AND idPaziente NOT IN (SELECT idPaziente FROM  StatiRegistro WHERE idStato=99)
			) p
			PIVOT
			(
			COUNT (tipo)
			FOR tipo IN
			( [M], [P] )
			) AS pvt
		END	

		/*controlla che il partecipante non sia già stato randomizzato*/
		if(SELECT COUNT(idPaziente) FROM _AnagraficaVerificaRandomiazzione WHERE idPaziente=@idPaziente AND randomizzazioneTrattamento IS NOT NULL)= 1
		BEGIN
			RETURN 
		END 
		BEGIN TRAN Randomizza
			/*Se i due gruppi sono bilanciati randomizza scegliento primo elemento libero dalla lista KIT*/
			/*1 recupera primo id libero per centro*/
			IF @contaM=@contaP 
				BEGIN
					SELECT TOP 1 @kit=KR.kit,@randomizzazioneTrattamento=TreatmentGroupDescription 
					FROM KitRandomizzazione KR
					WHERE Kit NOT IN (SELECT Kit FROM _KitFlaconiAssegnazione)
					AND Contenuto='850ml 62 pillole' 
					----AND ScadenzaFarmaco>=dateadd(month,2 ,getdate())  -- COPERTURA 2 mesi
					AND Lotto <> '-'
					AND reso = 0
					ORDER BY KR.kit ASC
				END
			ELSE
				BEGIN 
					IF @contaM>@contaP 
						BEGIN
							SELECT TOP 1 @kit=KR.kit,@randomizzazioneTrattamento=TreatmentGroupDescription 
							FROM KitRandomizzazione KR
							WHERE CONVERT(char(1), DecryptByPassPhrase('testAUDIT',TreatmentGroupDescription))='P'
							AND Kit NOT IN (SELECT Kit FROM _KitFlaconiAssegnazione)
							AND Contenuto='850ml 62 pillole' 
							---AND ScadenzaFarmaco>=dateadd(month,2 ,getdate())  -- COPERTURA 2 mesi
							AND Lotto <> '-'
							AND reso = 0
							ORDER BY KR.kit ASC
						END
					ELSE
						BEGIN
							SELECT TOP 1 @kit=KR.kit,@randomizzazioneTrattamento=TreatmentGroupDescription 
							FROM KitRandomizzazione KR
							WHERE CONVERT(char(1), DecryptByPassPhrase('testAUDIT',TreatmentGroupDescription))='M'
							AND Kit NOT IN (SELECT Kit FROM _KitFlaconiAssegnazione)
							AND Contenuto='850ml 62 pillole' 
							---AND ScadenzaFarmaco>=dateadd(month,2 ,getdate())  -- COPERTURA 2 mesi
							AND Lotto <> '-'
							AND reso = 0
							ORDER BY KR.kit ASC
						END
					
				
			END
			IF (@@ERROR <> 0) GOTO TRANS_FALLITA
			/*2 inserisce nel registro assegnazioni*/
			INSERT INTO _KitFlaconiAssegnazione (kit,utente,dataAssegnazione,idPaziente,idAssegnazioneElenco)
			VALUES(@kit,@utente,getdate(),@idPaziente,@idAssegnazioneElenco)
			IF (@@ERROR <> 0) GOTO TRANS_FALLITA
			/*3 imposta randomizzazione e data su Anagrafica*/
			UPDATE _AnagraficaVerificaRandomiazzione
			SET randomizzazioneTrattamento=@randomizzazioneTrattamento
			---,dataRandomizzazioneTrattamento=GETDATE()
			WHERE idPaziente=@idPaziente
			IF (@@ERROR <> 0) GOTO TRANS_FALLITA
		COMMIT TRAN Randomizza
		GOTO FINE
			
	TRANS_FALLITA:
	ROLLBACK TRAN Randomizza
	RETURN

	FINE:
	RETURN

END
GO
/****** Object:  StoredProcedure [dbo].[sp_ScadenziarioFlaconi]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===========================================================================================
-- Author:		Giuseppe Fornaciari
-- Create date: 05/07/2015
-- Description:	Lista pazienti e consegna farmaco
-- ===========================================================================================
CREATE PROCEDURE [dbo].[sp_ScadenziarioFlaconi]

 @dateDa as datetime = null
,@dateA as datetime =null

AS
IF @dateDa IS NULL AND @dateA IS NULL
BEGIN
	SELECT idPaziente,Nome,Cognome,cfiscale,dbo.dataProssimaConsegna(idPaziente) as 'prossimoRitiro'
	FROM Anagrafica 
	WHERE dbo.dataProssimaConsegna(idPaziente) is not null 
	AND idPaziente NOT IN (SELECT DISTINCT idPaziente FROM StatiRegistro INNER JOIN [DROP] on StatiRegistro.idStatoRegistro=[Drop].idStatoRegistro)
	ORDER BY dbo.dataProssimaConsegna(idPaziente) ASC
END
ELSE
BEGIN
	SELECT idPaziente,Nome,Cognome,cfiscale,dbo.dataProssimaConsegna(idPaziente) as 'prossimoRitiro'
	FROM Anagrafica 
	WHERE dbo.dataProssimaConsegna(idPaziente) is not null AND dbo.dataProssimaConsegna(idPaziente) between @dateDa and @dateA
	AND idPaziente NOT IN (SELECT DISTINCT idPaziente FROM StatiRegistro INNER JOIN [DROP] on StatiRegistro.idStatoRegistro=[Drop].idStatoRegistro)
	ORDER BY dbo.dataProssimaConsegna(idPaziente) ASC
END
GO
/****** Object:  StoredProcedure [dbo].[sp_StatisticaCampionamento]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_StatisticaCampionamento] 
AS
BEGIN
	SELECT 
	'probanda' as tipo
	,SUM(CASE WHEN randomizzazioneDieta=1 AND Sesso='M' THEN 1 ELSE 0 END) as 'B1M'
	,SUM(CASE WHEN randomizzazioneDieta=1 AND Sesso='F' THEN 1 ELSE 0 END) as 'B1F'
	,SUM(CASE WHEN randomizzazioneDieta=2 AND Sesso='M' THEN 1 ELSE 0 END) as 'B2M'
	,SUM(CASE WHEN randomizzazioneDieta=2 AND Sesso='F' THEN 1 ELSE 0 END) as 'B2F'
	FROM Anagrafica 
	WHERE famiglia=0 
	--AND idPaziente NOT IN (
	--SELECT 
	--idPaziente FROM StatiRegistro 
	--INNER JOIN StatiElenco ON StatiRegistro.idStato=StatiElenco.idStato
	--WHERE descrizione='drop'
	--)
	UNION
	SELECT 
	'familiare' as tipo
	,SUM(CASE WHEN randomizzazioneDieta=1 AND Sesso='M' THEN 1 ELSE 0 END) as 'B1M'
	,SUM(CASE WHEN randomizzazioneDieta=1 AND Sesso='F' THEN 1 ELSE 0 END) as 'B1F'
	,SUM(CASE WHEN randomizzazioneDieta=2 AND Sesso='M' THEN 1 ELSE 0 END) as 'B2M'
	,SUM(CASE WHEN randomizzazioneDieta=2 AND Sesso='F' THEN 1 ELSE 0 END) as 'B2F'
	FROM Anagrafica 
	WHERE famiglia<>0 
	--AND idPaziente NOT IN (
	--SELECT 
	--idPaziente FROM StatiRegistro 
	--INNER JOIN StatiElenco ON StatiRegistro.idStato=StatiElenco.idStato
	--WHERE descrizione='drop'
	--)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_StatisticaMagazzinoFarmaci]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_StatisticaMagazzinoFarmaci] 
AS
BEGIN
	SELECT 
	lotto
	,Sum(cast(reso as tinyint)) as resi
	,Count(b.kit) as assegnati
	,Count(A.kit)-(Count(b.kit)+Sum(cast(reso as tinyint))) as disponibili
	,Count(A.kit) as totale
	,dataConsegna
	, scadenzaFarmaco
	FROM [MeMeMe].[dbo].[KitRandomizzazione] A
	LEFT OUTER JOIN [MeMeMe].[dbo].KitFlaconiAssegnazione B ON A.Kit=B.kit
	WHERE lotto is not null
	GROUP BY lotto, dataConsegna, ScadenzaFarmaco
	ORDER BY DataConsegna
END
GO
/****** Object:  StoredProcedure [dbo].[sp_StatisticaRandomizzazione]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Author:		Giuseppe Fornaciari	
-- Create date: 24/02/2015
-- Description:	statistica di controllo bilanciamento randomizzazione
-- ==========================================================================================
CREATE PROCEDURE [dbo].[sp_StatisticaRandomizzazione] 
AS
BEGIN
    SELECT  
    SESSO as sesso,
    CASE WHEN (DATEDIFF(year,DataNascita,DataRandomizzazioneTrattamento))>=67 THEN '>=67' ELSE '<67' END as 'Eta',
    SUM(CASE WHEN CONVERT(char(1), DecryptByPassPhrase('testAUDIT',RandomizzazioneTrattamento))='P' THEN 1 ELSE 0 END) as 'X',
    SUM(CASE WHEN CONVERT(char(1), DecryptByPassPhrase('testAUDIT',RandomizzazioneTrattamento))='M' THEN 1 ELSE 0 END) as 'Y'
    FROM Anagrafica
    WHERE Anagrafica.dataRandomizzazioneTrattamento IS NOT NULL 
	--AND idPaziente NOT IN (
	--SELECT 
	--idPaziente FROM StatiRegistro 
	--INNER JOIN StatiElenco ON StatiRegistro.idStato=StatiElenco.idStato
	--WHERE descrizione='drop'
	--)  
    GROUP BY
    SESSO
    ,CASE WHEN (DATEDIFF(year,DataNascita,DataRandomizzazioneTrattamento))>=67 THEN '>=67' ELSE '<67' END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_StimaFabbisognioFlaconi]    Script Date: 14/01/2019 09:50:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Giuseppe Fornaciari
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_StimaFabbisognioFlaconi] 
 @dataConsegna varchar(20)
,@dataScadenza varchar(20)
,@msg varchar(max) OUTPUT
AS
BEGIN
	DECLARE @intTemp int
	DECLARE @dateTemp datetime
	--DECLARE @strTemp varchar(max)

	DECLARE @a int
	DECLARE @b1 int
	DECLARE @b2 int
	DECLARE @c int
	DECLARE @m int

	---SET @dataScadenza='20180715'
	---SET @dataConsegna='20170115'

	------------------------------------------------------------
	---- A stima fabbisogni delle persone IN STUDIO RANDOMIZZATE
	------------------------------------------------------------
	SET ANSI_WARNINGS OFF;

	select @dateTemp=max(TC.dataUltimaConsegna),@intTemp=SUM(TC.flaconiCumulatiUltimaConsegna)
	from Anagrafica as a
		cross apply MeMeMe.dbo.fabbisogniAScadenza(A.idPaziente, @dataScadenza) as TC

	SET @msg =  '<b>STIMA richiesta fornitura flaconi</b></br>' +
				'data scadenza: ' + convert(varchar(10), cast(@dataScadenza as date), 105) + '</br>' +
				'data consegna: ' + convert(varchar(10), cast(@dataConsegna as date), 105) + '</br>' +
				'copertura mesi: ' + cast(datediff(month, @dataConsegna,@dataScadenza) as varchar(2)) + '</br>' +
				'Ultima consegna secondo protocollo ' + convert(varchar(10), @dateTemp, 105)	
				+ '</br>'  +
				+ '</br>'  +
				+ 'Formula (A+b1+b2) - C' + '</br>'  +
				+ '</br>'  

	---PRINT @strTemp

	--SET @strTemp = ''
	--SET @strTemp =   'A ) flaconi necessari per paziente in studio: ' + cast(@intTemp as varchar(10)) 

	SET @msg = @msg + 'A ) flaconi necessari per paziente in studio: <b>' + cast(FORMAT(@intTemp, N'N0', 'it-IT') as varchar(10)) + '</b>' + '</br>'  
	---PRINT @strTemp
	SET @a = cast(@intTemp as varchar(10)) 	

	------------------------------------------------------------
	---- B stima fabbisogni delle perone IN STUDIO RANDOMIZZATE
	------------------------------------------------------------
	---SET @strTemp = ''
	SET @dateTemp = null
	SET @intTemp = null

	--- B1: da reclutare
	--- tasso di reclutamento mensile medio
	--- fabbisogno ipotetico per eccesso calcolato sul periodo scadenza, 1 flacone/mese per paziente a dosaggio pieno
	SELECT @intTemp=AVG(reclutamentoMensileMedio)
	*datediff(month, @dataConsegna,@dataScadenza)		--- mesi consegna-scadenza
	*1													--- 1 flacone mese
	*datediff(month, @dataConsegna,@dataScadenza)		--- mesi consegna-scadenza
	FROM 
	(
		SELECT count(a.dataRandomizzazioneDieta) as reclutamentoMensileMedio
		FROM Anagrafica A
		WHERE A.dataRandomizzazioneTrattamento is not null -- randomizzati TRATTAMENTO
		GROUP BY cast(datepart(year,convert(date,dataRandomizzazioneDieta)) as varchar(4)) + '-' + cast(datepart(month,convert(date,dataRandomizzazioneDieta)) as varchar(2))
	) as X

	--SET @strTemp =   'B1) Flaconi necessari per nuovi reclutamenti: ' + cast(@intTemp as varchar(10))
	
	--PRINT @strTemp
	SET @msg = @msg + 'B1) Flaconi necessari per nuovi reclutamenti: <b>' + cast(FORMAT(@intTemp, N'N0', 'it-IT') as varchar(10)) + '</b>' + '</br>' 
	SET @b1 = cast(@intTemp as varchar(10)) 

	-- B2: reclutati non ancora randomizzazti farmaco che passano randomizzazione


	--- se la scadenza della fornitura è inferiore al periodo medio in mesi da reclutamento 
	--- a randommizzazione, si ipotezza che tutte le persone in attesa verranno randomizzate e
	--- le si assegna un fabbisogno ipotetico per eccesso calcolato sul periodo scadenza, dosaggio pieno
	--- equivalente un flacone/mese per paziente
	--- SELECT data FROM Anagrafica WHERE dbo.idStatoCorrente(idPaziente)<8 ORDER BY data
	---SET @strTemp = ''
	SET @dateTemp = null
	SET @intTemp = null

	SELECT @intTemp=count(idPaziente)
	*1													--- 1 flacone mese
	*datediff(month, @dataConsegna,@dataScadenza)		--- mesi consegna-scadenza
	FROM Anagrafica WHERE dbo.idStatoCorrente(idPaziente)<8
	--SET @strTemp =   'B2) Flaconi necessari per i pazienti reclutati in attesa di randomizzazione: ' + cast(@intTemp as varchar(10))
	--PRINT @strTemp
	SET @msg = @msg + 'B2) Flaconi necessari per pazienti in attesa di randomizzazione: <b>' + cast(FORMAT(@intTemp, N'N0', 'it-IT') as varchar(10)) + '</b>' + '</br>' 

	SET @b2 = cast(@intTemp as varchar(10)) 

	------------------------------------------------------------
	-- C Fuoriusciti per DROP
	------------------------------------------------------------
	--SET @strTemp = ''
	SET @dateTemp = null
	SET @intTemp = null

	SELECT @intTemp=
		(SELECT
			(
			SELECT 
			convert(decimal(10,2),
				(
					SELECT count(a.idPaziente) as casi
					FROM Anagrafica A
					INNER JOIN StatiRegistro SR ON A.idPaziente=SR.idPaziente
					INNER JOIN StatiElenco SE ON SR.idStato=SE.idStato
					WHERE 
					(SR.idStato=99 -- stato di DROP
					AND a.randomizzazioneTrattamento IS NOT NULL)
				)
			)
			/
			convert(decimal(10,2),datediff(month,min(DataChiusura),max(DataChiusura)))
			FROM Anagrafica A
			INNER JOIN StatiRegistro SR ON A.idPaziente=SR.idPaziente
			)
			*
			datediff(month, getdate(), @dataScadenza)
		)
		*1											    --- 1 Flacone
		*datediff(month, getdate(), @dataScadenza)/2	--- metà periodo

		----SET @strTemp =   'C ) Flaconi non necessari per DROP: ' + cast(@intTemp as varchar(10))
		---PRINT @strTemp

	SET @msg = @msg + 'C ) Flaconi non necessari per DROP: <b>' + cast(format(@intTemp,N'N0','it-IT') as varchar(10)) + '</b>' + '</br>'  
	SET @c = cast(@intTemp as varchar(10)) 

	----- RISULTATO
	SET @msg = @msg + '</br>' 
	SET @msg = @msg + 'Fabbisogno complessivo: <b>' + cast(FORMAT((@a+@b1+@b2)-@c, N'N0', 'it-IT') as varchar(10)) + '</b>' + '</br>' 
	SELECT @m=count(*) FROM  [MeMeMe].[dbo].[KitRandomizzazione] WHERE lotto is not null AND reso=0 AND KIt NOT IN (SELECT Kit FROM KitFlaconiAssegnazione)
	SET @msg = @msg + 'Disponibilità attuale in magazzino: <b>' + cast(format(@m, N'N0', 'it-IT') as varchar(10)) + '</b>' + '</br>' 
	SET @msg = @msg + 'Richiesta flaconi: <b>' + cast(FORMAT(((@a+@b1+@b2)-@c)-@m, N'N0', 'it-IT') as varchar(10)) + '</b>'

	RETURN
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "vSTATA_Medas"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 222
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_PazientiConMedasPrimoAnno'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_PazientiConMedasPrimoAnno'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "StatiRegistro"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 2370
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_StatoCorrente'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_StatoCorrente'
GO
