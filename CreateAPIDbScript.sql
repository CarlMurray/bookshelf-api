USE [master]
GO
/****** Object:  Database [BookshelfAPI]    Script Date: 01/04/2024 16:54:07 ******/
CREATE DATABASE [BookshelfAPI]
GO
ALTER DATABASE [BookshelfAPI] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookshelfAPI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookshelfAPI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookshelfAPI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookshelfAPI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookshelfAPI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookshelfAPI] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookshelfAPI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookshelfAPI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookshelfAPI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookshelfAPI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookshelfAPI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookshelfAPI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookshelfAPI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookshelfAPI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookshelfAPI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookshelfAPI] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookshelfAPI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookshelfAPI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookshelfAPI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookshelfAPI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookshelfAPI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookshelfAPI] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BookshelfAPI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookshelfAPI] SET RECOVERY FULL 
GO
ALTER DATABASE [BookshelfAPI] SET  MULTI_USER 
GO
ALTER DATABASE [BookshelfAPI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookshelfAPI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookshelfAPI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookshelfAPI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookshelfAPI] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookshelfAPI] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookshelfAPI', N'ON'
GO
ALTER DATABASE [BookshelfAPI] SET QUERY_STORE = ON
GO
ALTER DATABASE [BookshelfAPI] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BookshelfAPI]
GO

/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 01/04/2024 16:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthorBook]    Script Date: 01/04/2024 16:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorBook](
	[AuthorsId] [int] NOT NULL,
	[BooksId] [int] NOT NULL,
 CONSTRAINT [PK_AuthorBook] PRIMARY KEY CLUSTERED 
(
	[AuthorsId] ASC,
	[BooksId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 01/04/2024 16:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 01/04/2024 16:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](3000) NOT NULL,
	[ISBN] [nvarchar](10) NOT NULL,
	[PublishDate] [datetime2](7) NOT NULL,
	[NumPages] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240317111934_Initial', N'8.0.3')
GO
INSERT [dbo].[AuthorBook] ([AuthorsId], [BooksId]) VALUES (30, 13)
INSERT [dbo].[AuthorBook] ([AuthorsId], [BooksId]) VALUES (31, 14)
INSERT [dbo].[AuthorBook] ([AuthorsId], [BooksId]) VALUES (32, 15)
INSERT [dbo].[AuthorBook] ([AuthorsId], [BooksId]) VALUES (33, 16)
INSERT [dbo].[AuthorBook] ([AuthorsId], [BooksId]) VALUES (34, 17)
INSERT [dbo].[AuthorBook] ([AuthorsId], [BooksId]) VALUES (35, 18)
INSERT [dbo].[AuthorBook] ([AuthorsId], [BooksId]) VALUES (36, 19)
INSERT [dbo].[AuthorBook] ([AuthorsId], [BooksId]) VALUES (37, 20)
INSERT [dbo].[AuthorBook] ([AuthorsId], [BooksId]) VALUES (38, 21)
INSERT [dbo].[AuthorBook] ([AuthorsId], [BooksId]) VALUES (38, 22)
INSERT [dbo].[AuthorBook] ([AuthorsId], [BooksId]) VALUES (39, 23)
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([Id], [Name]) VALUES (30, N'RB Whitaker')
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (31, N'Robert Martin')
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (32, N'David Thomas')
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (33, N'John Ousterhout')
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (34, N'Nir Eyal')
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (35, N'Don Norman')
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (36, N'Steve Krug')
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (37, N'Rob Fitzpatrick')
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (38, N'Marty Cagan')
INSERT [dbo].[Authors] ([Id], [Name]) VALUES (39, N'Teresa Torres')
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Title], [Description], [ISBN], [PublishDate], [NumPages]) VALUES (13, N'The C# Player''s Guide (5th Edition)', N'The book in your hands is a different kind of programming book. Like an entertaining video game, programming is an often challenging but always rewarding experience. This book shakes off the dusty, dull, dryness of the typical programming book, replacing it with something more exciting and flavorful: a bit of humor, a casual tone, and examples involving dragons and asteroids instead of bank accounts and employees.

And since you learn to program by doing instead of just reading, this book contains over 100 hands-on programming challenges. You will be building software instead of just reading about it. By completing the challenges, you’ll earn experience points, level up, and become a True C# Programmer!

This book covers the C# language from the ground up. It doesn’t assume you’ve been programming for years, but it also doesn’t hold back on exciting, powerful language features.', N'0985580151', CAST(N'2022-01-14T00:00:00.0000000' AS DateTime2), 495)
INSERT [dbo].[Books] ([Id], [Title], [Description], [ISBN], [PublishDate], [NumPages]) VALUES (14, N'Clean Code: A Handbook of Agile Software Craftmanship', N'Even bad code can function. But if code isn’t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way. Noted software expert Robert C. Martin presents a revolutionary paradigm with Clean Code: A Handbook of Agile Software Craftsmanship . Martin has teamed up with his colleagues from Object Mentor to distill their best agile practice of cleaning code “on the fly” into a book that will instill within you the values of a software craftsman and make you a better programmer—but only if you work at it. What kind of work will you be doing? You’ll be reading code—lots of code. And you will be challenged to think about what’s right about that code, and what’s wrong with it. More importantly, you will be challenged to reassess your professional values and your commitment to your craft.', N'9784512445', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 265)
INSERT [dbo].[Books] ([Id], [Title], [Description], [ISBN], [PublishDate], [NumPages]) VALUES (15, N'The Pragmatic Programmer', N'The Pragmatic Programmer is one of those rare tech books you''ll read, re-read, and read again over the years. Whether you''re new to the field or an experienced practitioner, you''ll come away with fresh insights each and every time.

Dave Thomas and Andy Hunt wrote the first edition of this influential book in 1999 to help their clients create better software and rediscover the joy of coding. These lessons have helped a generation of programmers examine the very essence of software development, independent of any particular language, framework, or methodology, and the Pragmatic philosophy has spawned hundreds of books, screencasts, and audio books, as well as thousands of careers and success stories.', N'1124998755', CAST(N'2019-12-02T00:00:00.0000000' AS DateTime2), 411)
INSERT [dbo].[Books] ([Id], [Title], [Description], [ISBN], [PublishDate], [NumPages]) VALUES (16, N'The Philosophy of Sofware Design', N'This book addresses the topic of software design: how to decompose complex software systems into modules (such as classes and methods) that can be implemented relatively independently. The book first introduces the fundamental problem in software design, which is managing complexity. It then discusses philosophical issues about how to approach the software design process and it presents a collection of design principles to apply during software design. The book also introduces a set of red flags that identify design problems. You can apply the ideas in this book to minimize the complexity of large software systems, so that you can write software more quickly and cheaply.', N'9987546452', CAST(N'2021-07-26T00:00:00.0000000' AS DateTime2), 355)
INSERT [dbo].[Books] ([Id], [Title], [Description], [ISBN], [PublishDate], [NumPages]) VALUES (17, N'Hooked: How to Build Habit-forming Products', N'Why do some products capture our attention while others flop?
What makes us engage with certain things out of sheer habit?
Is there an underlying pattern to how technologies hook us?

Nir Eyal answers these questions (and many more) with the Hook Model – a four-step process that, when embedded into products, subtly encourages customer behaviour. Through consecutive "hook cycles," these products bring people back again and again.

Eyal provides readers with practical insights to create user habits that stick; actionable steps for building products people love; and riveting examples, from the iPhone to Twitter, Instagram and Google.', N'9765622000', CAST(N'2020-12-05T00:00:00.0000000' AS DateTime2), 124)
INSERT [dbo].[Books] ([Id], [Title], [Description], [ISBN], [PublishDate], [NumPages]) VALUES (18, N'The Design of Everyday Things', N'The Ultimate Guide To Human-Centered Design Even The Smartest Among Us Can Feel Inept As We Fail To Figure Out Which Light Switch Or Oven Burner To Turn On, Or Whether To Push, Pull, Or Slide A Door. The Fault, Argues This Ingenious -- Even Liberating -- Book, Lies Not In Ourselves, But In Product Design That Ignores The Needs Of Users And The Principles Of Cognitive Psychology. The Problems Range From Ambiguous And Hidden Controls To Arbitrary Relationships Between Controls And Functions, Coupled With A Lack Of Feedback Or Other Assistance And Unreasonable Demands On Memorization.The Design Of Everyday Things Shows That Good, Usable Design Is Possible. The Rules Are Simple: Make Things Visible, Exploit Natural Relationships That Couple Function And Control, And Make Intelligent Use Of Constraints. The Goal: Guide The User Effortlessly To The Right Action On The Right Control At The Right Time.The Design Of Everyday Things Is A Powerful Primer On How -- And Why -- Some Products Satisfy Customers While Others Only Frustrate Them.', N'4456899852', CAST(N'2013-11-05T00:00:00.0000000' AS DateTime2), 234)
INSERT [dbo].[Books] ([Id], [Title], [Description], [ISBN], [PublishDate], [NumPages]) VALUES (19, N'Don''t Make Me Think', N'Hundreds of thousands of Web designers and developers have relied on web usability expert Steve Krug''s guide to help them understand the principles of intuitive navigation and information design. Witty, commonsensical, and eminently practical, it''s one of the best-loved and most recommended books on the subject.', N'9778455498', CAST(N'2016-02-12T00:00:00.0000000' AS DateTime2), 122)
INSERT [dbo].[Books] ([Id], [Title], [Description], [ISBN], [PublishDate], [NumPages]) VALUES (20, N'The Mom Test', N'The Mom Test is a quick, practical guide that will save you time, money, and heartbreak.

They say you shouldn''t ask your mom whether your business is a good idea, because she loves you and will lie to you. This is technically true, but it misses the point. You shouldn''t ask anyone if your business is a good idea. It''s a bad question and everyone will lie to you at least a little . As a matter of fact, it''s not their responsibility to tell you the truth. It''s your responsibility to find it and it''s worth doing right .

Talking to customers is one of the foundational skills of both Customer Development and Lean Startup. We all know we''re supposed to do it, but nobody seems willing to admit that it''s easy to screw up and hard to do right. This book is going to show you how customer conversations go wrong and how you can do better.', N'6886549985', CAST(N'2019-05-23T00:00:00.0000000' AS DateTime2), 145)
INSERT [dbo].[Books] ([Id], [Title], [Description], [ISBN], [PublishDate], [NumPages]) VALUES (21, N'Transformed: Moving to the Product Operating Model', N'Help transform your business and innovate like the world''s top tech companies!

In INSPIRED, product thought leader Marty Cagan revealed the best practices and techniques used by the top product teams operating in the product model. Next, EMPOWERED shared the best practices and techniques used by the top product leaders to provide their teams with the kind of environment they need to thrive in the product model.

Yet, the most common question after reading INSPIRED and EMPOWERED has been: "Yes, we want to work this way, but the way we work today is so different, and so deeply ingrained, is it even possible for a company like ours to transform to the product model?"', N'9283327422', CAST(N'2021-12-12T00:00:00.0000000' AS DateTime2), 243)
INSERT [dbo].[Books] ([Id], [Title], [Description], [ISBN], [PublishDate], [NumPages]) VALUES (22, N'Inspired: How to Create Tech Products Customers Love', N'How do today''s most successful tech companies-Amazon, Google, Facebook, Netflix, Tesla-design, develop, and deploy the products that have earned the love of literally billions of people around the world? Perhaps surprisingly, they do it very differently than the vast majority of tech companies. In INSPIRED, technology product management thought leader Marty Cagan provides readers with a master class in how to structure and staff a vibrant and successful product organization, and how to discover and deliver technology products that your customers will love-and that will work for your business. With sections on assembling the right people and skillsets, discovering the right product, embracing an effective yet lightweight process, and creating a strong product culture, readers can take the information they learn and immediately leverage it within their own organizations-dramatically improving their own product efforts. Whether you''re an early stage startup working to get to product/market fit, or a growth-stage company working to scale your product organization, or a large, long-established company trying to regain your ability to consistently deliver new value for your customers, INSPIRED will take you and your product organization to a new level of customer engagement, consistent innovation, and business success.', N'7743829238', CAST(N'2022-08-18T00:00:00.0000000' AS DateTime2), 275)
INSERT [dbo].[Books] ([Id], [Title], [Description], [ISBN], [PublishDate], [NumPages]) VALUES (23, N'Continuous Discovery Habits', N'"If you haven''t had the good fortune to be coached by a strong leader or product coach, this book can help fill that gap and set you on the path to success."
- Marty Cagan

How do you know that you are making a product or service that your customers want? How do you ensure that you are improving it over time? How do you guarantee that your team is creating value for your customers in a way that creates value for your business?

In this book, you''ll learn a structured and sustainable approach to continuous discovery that will help you answer each of these questions, giving you the confidence to act while also preparing you to be wrong. You''ll learn to balance action with doubt so that you can get started without being blindsided by what you don''t get right.

If you want to discover products that customers love-that also deliver business results-this book is for you.', N'9099802847', CAST(N'2019-09-19T00:00:00.0000000' AS DateTime2), 274)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
/****** Object:  Index [IX_AuthorBook_BooksId]    Script Date: 01/04/2024 16:54:07 ******/
CREATE NONCLUSTERED INDEX [IX_AuthorBook_BooksId] ON [dbo].[AuthorBook]
(
	[BooksId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AuthorBook]  WITH CHECK ADD  CONSTRAINT [FK_AuthorBook_Authors_AuthorsId] FOREIGN KEY([AuthorsId])
REFERENCES [dbo].[Authors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AuthorBook] CHECK CONSTRAINT [FK_AuthorBook_Authors_AuthorsId]
GO
ALTER TABLE [dbo].[AuthorBook]  WITH CHECK ADD  CONSTRAINT [FK_AuthorBook_Books_BooksId] FOREIGN KEY([BooksId])
REFERENCES [dbo].[Books] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AuthorBook] CHECK CONSTRAINT [FK_AuthorBook_Books_BooksId]
GO
USE [master]
GO
ALTER DATABASE [BookshelfAPI] SET  READ_WRITE 
GO
