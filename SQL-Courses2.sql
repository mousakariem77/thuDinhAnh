CREATE DATABASE Project_Group03
GO

USE Project_Group03
GO

CREATE TABLE [admin]--
(
    [adminID] INT IDENTITY (1,1) PRIMARY KEY,
    [username] VARCHAR(50),
    [password] VARCHAR(50)
);
GO

CREATE TABLE [learner]--
(
    [learnerID] INT IDENTITY (1,1) PRIMARY KEY,
    [first_name] NVARCHAR(50),
    [last_name] NVARCHAR(50),
    [gender] NVARCHAR(10),
    [birthday] DATE,
    [phoneNumber] VARCHAR(20),
    [email] VARCHAR(30),
    [country] NVARCHAR(255),
    [username] VARCHAR(50),
    [password] VARCHAR(50),
    [picture] TEXT,
    [registration_Date] DATE,
    [wallet] MONEY,
    [status] NVARCHAR(30)
);
GO

CREATE TABLE [instructor]--
(
    [instructorID] INT IDENTITY (1,1) PRIMARY KEY,
    [first_name] NVARCHAR(50),
    [last_name] NVARCHAR(50),
    [gender] NVARCHAR(10),
    [birthday] DATE,
    [phoneNumber] VARCHAR(20),
    [email] VARCHAR(30),
    [country] NVARCHAR(255),
    [username] VARCHAR(50),
    [password] VARCHAR(50),
    [picture] TEXT,
    [registration_Date] DATE,
    [income] MONEY,
	[introduce] NTEXT,
    [status] NVARCHAR(30)
);
GO

CREATE TABLE [categories] (--
    [categoryID] INT IDENTITY (1,1) PRIMARY KEY,
    [category_name] NVARCHAR(255),
    [description] NTEXT
);
GO

CREATE TABLE [courses] (--
    [courseID] INT IDENTITY (1,1) PRIMARY KEY,
    [categoryID] INT,
    [course_name] NVARCHAR(255),
    [description] NTEXT,
    [picture] TEXT,
    [total_time] INT DEFAULT 0,
    [price] MONEY,
    [startDate] DATE,
    [endDate] DATE,
    [status] NVARCHAR(30),
    FOREIGN KEY ([categoryID]) REFERENCES [categories]([categoryID])
);
GO

CREATE TABLE [instruct]
(
    [instructID] INT IDENTITY (1,1) PRIMARY KEY,
    [courseID] INT,
    [instructorID] INT,
    FOREIGN KEY ([instructorID]) REFERENCES [instructor]([instructorID]),
    FOREIGN KEY ([courseID]) REFERENCES [courses]([courseID]),
    UNIQUE ([instructorID], [courseID])
);
GO

CREATE TABLE [chapter]--
(
    [chapterID] INT IDENTITY (1,1) PRIMARY KEY,
    [courseID] INT,
    [chapter_name] NVARCHAR(50),
    [index] INT,
    [description] NTEXT,
    [total_time] INT DEFAULT 0,
    FOREIGN KEY (courseID) REFERENCES [courses](courseID)
);
GO

CREATE TABLE [lesson]--
(
    [lessonID] INT IDENTITY (1,1) PRIMARY KEY,
    [chapterID] INT,
    [lesson_name] NVARCHAR(50),
    [description] NTEXT,
    [percent_to_passed] INT DEFAULT 80,
    [must_be_completed] BIT DEFAULT 1,
    [content] NTEXT,
    [index] INT,
    [type] INT,
    [time] INT DEFAULT 0 ,
    FOREIGN KEY (chapterID) REFERENCES [chapter](chapterID)
);
GO

CREATE TABLE [voucher] (
    [voucherID] INT IDENTITY (1,1) PRIMARY KEY,
	[adminID] INT, 
	[courseID] INT,
    [percent_discount] INT,
	[start_at] DATETIME,
    [end_at]   DATETIME,
	[AllCourse] BIT,
    [IsActive] BIT,
    FOREIGN KEY ([adminID]) REFERENCES [admin](adminID),
    FOREIGN KEY ([courseID]) REFERENCES [courses](courseID)
);
GO

CREATE TABLE [courseVoucher](
	[CourseVoucherID] INT IDENTITY (1,1) PRIMARY KEY,
	[voucherID] INT,
	[courseID] INT,
    FOREIGN KEY ([voucherID]) REFERENCES [voucher]([voucherID]),
    FOREIGN KEY ([courseID]) REFERENCES [courses]([courseID])
);
GO

INSERT INTO [admin] ([username], [password])
VALUES ('admin123', 'password123');
GO

INSERT INTO [learner] 
([first_name], [last_name], [gender], [birthday], [phoneNumber], [email], [country], [username], [password], [picture], [registration_Date], [wallet], [status])
VALUES
(N'John', N'Doe', 'Male', '1990-05-15', '0963820388', 'doe@gmail.com', 'USA', 'doe', 'password123', NULL, '2023-01-01', 100.00, 'Active'),
(N'Jane', N'Smith', 'Female', '1995-08-20', '0983792526', 'smith@gmail.com', 'Canada', 'janesmith', 'password456', NULL, '2023-01-02', 50.00, 'Active'),
(N'Michael', N'Johnson', 'Male', '1988-11-10', '0987654321', 'johnson@gmail.com', 'UK', 'johnson', 'password789', NULL, '2023-01-03', 75.00, 'Active'),
(N'Emily', N'Brown', 'Female', '1993-04-25', '0984831945', 'brown@gmail.com', 'Australia', 'emily', 'passwordabc', NULL, '2023-01-04', 120.00, 'Active'),
(N'William', N'Davis', 'Male', '1992-09-18', '0847105822', 'davis@gmail.com', 'New Zealand', 'davis', 'passworddef', NULL, '2023-01-05', 90.00, 'Active'),
(N'Sophia', N'Wilson', 'Female', '1997-12-05', '0957238919', 'wilson@gmail.com', 'Germany', 'wilson', 'passwordghi', NULL, '2023-01-06', 200.00, 'Active');
GO

INSERT INTO [instructor] 
([first_name], [last_name], [gender], [birthday], [phoneNumber], [email], [country], [username], [password], [picture], [registration_Date], [income], [introduce], [status])
VALUES
(N'Nguyễn', N'Văn A', 'Male', '1985-03-10', '0987654321', 'nguyenvana@gmail.com', 'Vietnam', 'nguyenvana', 'password123', NULL, '2023-01-01', 500.00, N'Tôi là một giáo viên có kinh nghiệm trong lĩnh vực này.', 'Active'),
(N'Trần', N'Thị B', 'Female', '1990-07-15', '0912345678', 'tranthib@gmail.com', 'Vietnam', 'tranthib', 'password456', NULL, '2023-01-02', 700.00, N'Tôi đã giảng dạy nhiều khóa học về chủ đề này.', 'Active'),
(N'Phạm', N'Văn C', 'Male', '1988-12-20', '0971234567', 'phamvanc@gmail.com', 'Vietnam', 'phamvanc', 'password789', NULL, '2023-01-03', 600.00, N'Tôi mong muốn chia sẻ kiến thức của mình với các học viên.', 'Active');
GO

INSERT INTO [categories] 
([category_name], [description])
VALUES
('Technology', 'This category includes courses related to technology such as programming, software development, and networking.'),
('Business', 'Courses under this category focus on business management, entrepreneurship, and finance.'),
('Language', 'Language courses cover various languages including English, Spanish, French, and Chinese.'),
('Health & Fitness', 'This category offers courses on health, fitness, nutrition, and wellness.'),
('Arts & Crafts', 'Arts and crafts category includes courses on painting, drawing, pottery, and other creative activities.'),
('Science & Engineering', 'This category covers courses related to science, engineering, physics, chemistry, and electronics.'),
('Personal Development', 'Courses in this category focus on personal development, soft skills, leadership, time management, and creative thinking.'),
('Music & Entertainment', 'This category offers courses on music, performing arts, singing, dancing, theater, and entertainment.'),
('Career Development', 'Courses under this category provide guidance on career development, job searching, interviews, resume building, and career management.'),
('Lifestyle & Hobbies', 'This category includes courses on lifestyle, personal hobbies, cooking, photography, travel, interior decoration, and local culture.');
GO

INSERT INTO [courses] 
([categoryID], [course_name], [description], [picture], [total_time], [price], [startDate], [endDate], [status])
VALUES
(1, 'Introduction to Python Programming', 'This course provides an introduction to Python programming language.', NULL, 30, 49.00, '2024-03-01', '2024-04-01', 'Active'),
(1, 'Web Development with HTML & CSS', 'Learn how to create responsive websites using HTML and CSS.', NULL, 45, 79.00, '2024-03-15', '2024-04-15', 'Active'),
(2, 'Introduction to Business Management', 'Explore the fundamentals of business management and organization.', NULL, 60, 99.00, '2024-04-01', '2024-05-01', 'Active'),
(2, 'Financial Planning for Beginners', 'Learn how to manage personal finances and plan for the future.', NULL, 30, 59.00, '2024-04-15', '2024-05-15', 'Active'),
(3, 'English Conversation Practice', 'Practice English conversation skills with native speakers.', NULL, 60, 69.00, '2024-05-01', '2024-06-01', 'Active'),
(3, 'French Language Basics', 'Beginner course covering basic French language skills.', NULL, 45, 49.00, '2024-05-15', '2024-06-15', 'Active'),
(4, 'Yoga for Beginners', 'Learn the basics of yoga including poses and breathing techniques.', NULL, 30, 29.00, '2024-06-01', '2024-07-01', 'Active'),
(4, 'Healthy Eating Habits', 'Discover the importance of nutrition and healthy eating habits.', NULL, 45, 39.00, '2024-06-15', '2024-07-15', 'Active'),
(5, 'Introduction to Watercolor Painting', 'Learn the basics of watercolor painting techniques.', NULL, 60, 89.00, '2024-07-01', '2024-08-01', 'Active'),
(5, 'Pottery Making Workshop', 'Hands-on workshop covering pottery making techniques.', NULL, 90, 129.00, '2024-07-15', '2024-08-15', 'Active');
GO

-- Ánh xạ giữa các khóa học và giáo viên tương ứng
-- Nguyễn Văn A - Introduction to Python Programming
-- Trần Thị B - Web Development with HTML & CSS
-- Phạm Văn C - Introduction to Business Management
-- Phạm Văn C - Financial Planning for Beginners
-- Nguyễn Văn A - English Conversation Practice
-- Trần Thị B - French Language Basics
-- Phạm Văn C - Yoga for Beginners
-- Nguyễn Văn A - Healthy Eating Habits
-- Trần Thị B - Introduction to Watercolor Painting
-- Phạm Văn C - Pottery Making Workshop

-- Tạo thông tin cho bảng instruct
INSERT INTO [instruct] ([courseID], [instructorID]) VALUES (1, 1);
INSERT INTO [instruct] ([courseID], [instructorID]) VALUES (2, 2);
INSERT INTO [instruct] ([courseID], [instructorID]) VALUES (3, 3);
INSERT INTO [instruct] ([courseID], [instructorID]) VALUES (4, 3);
INSERT INTO [instruct] ([courseID], [instructorID]) VALUES (5, 1);
INSERT INTO [instruct] ([courseID], [instructorID]) VALUES (6, 2);
INSERT INTO [instruct] ([courseID], [instructorID]) VALUES (7, 3);
INSERT INTO [instruct] ([courseID], [instructorID]) VALUES (8, 1);
INSERT INTO [instruct] ([courseID], [instructorID]) VALUES (9, 2);
INSERT INTO [instruct] ([courseID], [instructorID]) VALUES (10, 3);
GO

-- Tạo thông tin cho bảng Chapter
-- Chapter cho khóa học "Introduction to Python Programming"
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (1, 'Introduction', 1, 'Introduction to Python programming language', 10);
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (1, 'Variables and Data Types', 2, 'Understanding variables and data types in Python', 20);

-- Chapter cho khóa học "Web Development with HTML & CSS"
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (2, 'HTML Basics', 1, 'Introduction to HTML basics', 15);
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (2, 'CSS Basics', 2, 'Introduction to CSS basics', 20);

-- Chapter cho khóa học "Introduction to Business Management"
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (3, 'Introduction to Business', 1, 'Introduction to business fundamentals', 20);
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (3, 'Management Principles', 2, 'Understanding management principles', 25);

-- Chapter cho khóa học "Financial Planning for Beginners"
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (4, 'Personal Finance Basics', 1, 'Introduction to personal finance basics', 20);
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (4, 'Financial Planning', 2, 'Learn about financial planning for the future', 25);

-- Chapter cho khóa học "English Conversation Practice"
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (5, 'Greetings and Introductions', 1, 'Practice greetings and introductions in English', 15);
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (5, 'Everyday Conversations', 2, 'Practice everyday conversations in English', 25);

-- Chapter cho khóa học "French Language Basics"
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (6, 'Basic French Phrases', 1, 'Learn basic French phrases for everyday use', 20);
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (6, 'Introduction to French Grammar', 2, 'Introduction to basic French grammar concepts', 25);

-- Chapter cho khóa học "Yoga for Beginners"
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (7, 'Yoga Basics', 1, 'Introduction to yoga basics and poses', 20);
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (7, 'Breathing Techniques', 2, 'Learn about different breathing techniques in yoga', 25);

-- Chapter cho khóa học "Healthy Eating Habits"
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (8, 'Nutrition Basics', 1, 'Introduction to nutrition basics', 20);
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (8, 'Healthy Meal Planning', 2, 'Learn how to plan healthy meals', 25);

-- Chapter cho khóa học "Introduction to Watercolor Painting"
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (9, 'Watercolor Techniques', 1, 'Introduction to watercolor painting techniques', 25);
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (9, 'Color Mixing', 2, 'Learn about color mixing techniques in watercolor', 35);

-- Chapter cho khóa học "Pottery Making Workshop"
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (10, 'Pottery Basics', 1, 'Introduction to pottery basics and techniques', 30);
INSERT INTO [chapter] ([courseID], [chapter_name], [index], [description], [total_time]) VALUES (10, 'Hand-building Techniques', 2, 'Learn about hand-building techniques in pottery', 40);
GO

-- Tạo thông tin cho bảng Lesson
-- Lesson cho Chapter 1
INSERT INTO [lesson] ([chapterID], [lesson_name], [description], [content], [index], [type], [time])
VALUES (1, 'Python Basics', 'Introduction to Python basics', 'Lesson content goes here...', 1, 1, 30);

-- Lesson cho Chapter 2
INSERT INTO [lesson] ([chapterID], [lesson_name], [description], [content], [index], [type], [time])
VALUES (2, 'HTML Tags', 'Introduction to HTML tags', 'Lesson content goes here...', 1, 1, 30);

-- Lesson cho Chapter 3
INSERT INTO [lesson] ([chapterID], [lesson_name], [description], [content], [index], [type], [time])
VALUES (3, 'Introduction to Business', 'Introduction to business fundamentals', 'Lesson content goes here...', 1, 1, 30);

-- Lesson cho Chapter 4
INSERT INTO [lesson] ([chapterID], [lesson_name], [description], [content], [index], [type], [time])
VALUES (4, 'Personal Finance Basics', 'Introduction to personal finance basics', 'Lesson content goes here...', 1, 1, 30);

-- Lesson cho Chapter 5
INSERT INTO [lesson] ([chapterID], [lesson_name], [description], [content], [index], [type], [time])
VALUES (5, 'Greetings', 'Practice greetings in English', 'Lesson content goes here...', 1, 1, 30);

-- Lesson cho Chapter 6
INSERT INTO [lesson] ([chapterID], [lesson_name], [description], [content], [index], [type], [time])
VALUES (6, 'Basic French Phrases', 'Learn basic French phrases', 'Lesson content goes here...', 1, 1, 30);

-- Lesson cho Chapter 7
INSERT INTO [lesson] ([chapterID], [lesson_name], [description], [content], [index], [type], [time])
VALUES (7, 'Introduction to Yoga', 'Introduction to yoga basics', 'Lesson content goes here...', 1, 1, 30);

-- Lesson cho Chapter 8
INSERT INTO [lesson] ([chapterID], [lesson_name], [description], [content], [index], [type], [time])
VALUES (8, 'Nutrition Basics', 'Introduction to nutrition basics', 'Lesson content goes here...', 1, 1, 30);

-- Lesson cho Chapter 9
INSERT INTO [lesson] ([chapterID], [lesson_name], [description], [content], [index], [type], [time])
VALUES (9, 'Watercolor Techniques', 'Introduction to watercolor painting techniques', 'Lesson content goes here...', 1, 1, 30);

-- Lesson cho Chapter 10
INSERT INTO [lesson] ([chapterID], [lesson_name], [description], [content], [index], [type], [time])
VALUES (10, 'Pottery Basics', 'Introduction to pottery basics', 'Lesson content goes here...', 1, 1, 30);
GO
















---------------------------


CREATE TABLE [enrollment] (
    [enrollmentID] INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    [learnerID] INT,
    [courseID] INT,
    [enrollmentDate] DATE,
    [status] NVARCHAR(30),
    FOREIGN KEY ([learnerID]) REFERENCES [learner]([learnerID]),
    FOREIGN KEY ([courseID]) REFERENCES [courses]([courseID])
);
GO


CREATE TABLE [course_progress]
(
    [course_progressID] INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    [learnerID] INT,
    [courseID] INT,
    [enrolled] BIT DEFAULT 0,
    [completed] BIT DEFAULT 0,
    [progress_percent] INT DEFAULT 0,
    [rated] BIT DEFAULT 0,
    [total_time] INT DEFAULT 0,
    [start_at] DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (learnerID) REFERENCES [learner](learnerID),
    FOREIGN KEY (courseID) REFERENCES [courses](courseID)
);
GO

CREATE TABLE [chapter_progress]
(
    [chapter_progressID] INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    [chapterID] INT,
    [course_progressID] INT,
    [progress_percent] INT DEFAULT 0,
    [completed] BIT DEFAULT 0,
    [total_time] INT DEFAULT 0,
    [start_at] DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (chapterID) REFERENCES [chapter](chapterID),
    FOREIGN KEY (course_progressID) REFERENCES [course_progress](course_progressID)
);
GO

CREATE TABLE [lesson_progress]
(
    [lesson_progressID] INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    [lessonID] INT,
    [chapter_progressID] INT,
    [progress_percent] INT DEFAULT 0,
    [completed] BIT DEFAULT 0,
    [start_at] DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (lessonID) REFERENCES [lesson](lessonID),
    FOREIGN KEY (chapter_progressID) REFERENCES [chapter_progress](chapter_progressID)
);
GO

CREATE TABLE [question]
(
	[questionID] INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	[lessonID] INT,
	[startTime] DATETIME DEFAULT CURRENT_TIMESTAMP,
	[endTime] DATETIME DEFAULT CURRENT_TIMESTAMP,
	[index] INT,
	[content] NTEXT,
	[type] INT,
	[mark] INT DEFAULT 1,
	FOREIGN KEY (lessonID) REFERENCES lesson(lessonID)
);
GO

CREATE TABLE [answer]
(
	[answerID] INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	[questionID] INT,
	[content] NTEXT,
	[correct] BIT DEFAULT 0,
	FOREIGN KEY (questionID) REFERENCES question
);
GO

CREATE TABLE [question_result]
(
	[question_resultID] INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	[lesson_progressID] INT,
	[number_of_correct_answer] INT,
	[number_of_question] INT,
	[mark] INT,
	[start_at] DATETIME,
	[end_at] DATETIME,
	[learnerID] VARCHAR(10),
	[instructorID] VARCHAR(10),
	FOREIGN KEY (learnerID) REFERENCES learner,
	FOREIGN KEY (instructorID) REFERENCES instructor
);
GO

CREATE TABLE [result]
(
	[resultID] INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	[question_resultID] INT,
	[lessonID] INT,
	[mark] INT,
	FOREIGN KEY (question_resultID) REFERENCES question_result,
	FOREIGN KEY (lessonID) REFERENCES lesson
);
GO

CREATE TABLE [chosen_answer]
(
	[chosen_answerID] INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	[questionID] INT,
	[answerID] INT,
	[question_resultID] INT,
	[learnerID] INT,
	FOREIGN KEY ([question_resultID]) REFERENCES question_result,
	FOREIGN KEY ([answerID]) REFERENCES answer,
	FOREIGN KEY ([questionID]) REFERENCES question,
	FOREIGN KEY ([learnerID]) REFERENCES learner
);
GO

CREATE TABLE [transaction]
(
    [transactionID] INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    [learnerID] INT,
    [courseID] INT,
	[enrollment_date] DATE,
    [origin_price]  NUMERIC(10, 2),
    [price] NUMERIC(10, 2),
    [description] NTEXT,
    [status] INT DEFAULT 0,
    FOREIGN KEY (learnerID) REFERENCES [learner](learnerID),
    FOREIGN KEY (courseID) REFERENCES [courses](courseID)
);
GO

CREATE TABLE [receiverType] (
	[receiverTypeID] INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	[typeName] NVARCHAR(50) UNIQUE
);
GO

CREATE TABLE [notification] (
    [notificationID] INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    [receiverID] INT,
	[receiverTypeID] INT, --- Loại người nhận (learner, instructor, admin, etc.)
    [messageType] NVARCHAR(50), -- Loại thông báo (ví dụ: Announcement, QuizReminder, etc.)
    [message] NTEXT,
    [sent_date] DATETIME,
    [isRead] BIT, -- Kiểm tra xem thông báo đã được đọc chưa
	FOREIGN KEY (ReceiverID) REFERENCES [admin](adminID) ON DELETE CASCADE,
    FOREIGN KEY (ReceiverID) REFERENCES [learner](learnerID) ON DELETE CASCADE,
    FOREIGN KEY (ReceiverID) REFERENCES [instructor](instructorID) ON DELETE CASCADE,
	FOREIGN KEY ([receiverTypeID]) REFERENCES [receiverType](receiverTypeID)
);
GO

CREATE TABLE [review] (
	[reviewID] INT IDENTITY (1,1) PRIMARY KEY NOT NULL,,
	[courseID] INT,
	[rating] INT CHECK (rating >= 1 AND rating <= 5),
	[comment] NVARCHAR(MAX),
	[img] VARCHAR(MAX),
	[icon] NVARCHAR(50),
	[review_date] DATE
);
GO

CREATE TABLE [review_course] (
	[reviewID] INT,
	[learnerID] VARCHAR(10),
	FOREIGN KEY ([reviewID]) REFERENCES review,
	FOREIGN KEY ([learnerID]) REFERENCES learner([learnerID])
);
GO



--------------------------------------các bảng nâng cao, mở rộng nếu kịp---------------------------------------
CREATE TABLE [payment] (
    [paymentID] VARCHAR(10) PRIMARY KEY,
    [learnerID] VARCHAR(10),
	[account_number] INT,
	[account_name] NVARCHAR(255),
	[bank] NVARCHAR(255),
    [status] BIT DEFAULT 0,
    FOREIGN KEY (learnerID) REFERENCES learner(learnerID),
);
GO

CREATE TABLE [Receiver_Messages] (
    [MessageID] INT PRIMARY KEY,
	[UserID] VARCHAR(10),
    [MessageType] NVARCHAR(50), -- Loại tin nhắn (ví dụ: TextMessage, ImageMessage, etc.)
    [MessageText] NTEXT,
    [SentDate] DATETIME,
    [IsRead] BIT, -- Kiểm tra xem tin nhắn đã được đọc chưa
    FOREIGN KEY (UserID) REFERENCES learner(learnerID) ON DELETE CASCADE,
    FOREIGN KEY (UserID) REFERENCES instructor(instructorID) ON DELETE CASCADE
	-- tự động xóa các tin nhắn liên quan khi một sinh viên hoặc giáo viên bị xóa khỏi hệ thống
);
GO

CREATE TABLE [Send_Messages] (
    [MessageID] INT PRIMARY KEY,
	[UserID] VARCHAR(10),
    [IsSender] BIT,
    [MessageType] NVARCHAR(50), -- Loại tin nhắn (ví dụ: TextMessage, ImageMessage, etc.)
    [MessageText] NTEXT,
    [SentDate] DATETIME,
    [IsRead] BIT, -- Kiểm tra xem tin nhắn đã được đọc chưa
    FOREIGN KEY (UserID) REFERENCES learner(learnerID) ON DELETE CASCADE,
    FOREIGN KEY (UserID) REFERENCES instructor(instructorID) ON DELETE CASCADE
	-- tự động xóa các tin nhắn liên quan khi một sinh viên hoặc giáo viên bị xóa khỏi hệ thống
);
GO
