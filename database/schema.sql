
-- Core tables (Azure SQL)

CREATE TABLE Players (
  PlayerId INT IDENTITY PRIMARY KEY,
  DisplayName NVARCHAR(80) NOT NULL,
  IsActive BIT NOT NULL DEFAULT 1
);

CREATE TABLE Positions (
  PositionCode NVARCHAR(2) PRIMARY KEY,  -- '1'..'11'
  DisplayName NVARCHAR(50) NOT NULL
);

CREATE TABLE PlayerPositions (
  PlayerId INT NOT NULL,
  PositionCode NVARCHAR(2) NOT NULL,
  PreferenceLevel TINYINT NOT NULL,
  CONSTRAINT PK_PlayerPositions PRIMARY KEY (PlayerId, PositionCode),
  CONSTRAINT FK_PlayerPositions_Player FOREIGN KEY (PlayerId) REFERENCES Players(PlayerId),
  CONSTRAINT FK_PlayerPositions_Position FOREIGN KEY (PositionCode) REFERENCES Positions(PositionCode)
);

CREATE TABLE Matches (
  MatchId INT IDENTITY PRIMARY KEY,
  MatchDate DATE NOT NULL,
  Opponent NVARCHAR(80) NULL,
  HomeAway NVARCHAR(10) NULL,
  OurScore INT NOT NULL DEFAULT 0,
  TheirScore INT NOT NULL DEFAULT 0,
  Notes NVARCHAR(4000) NULL
);

CREATE TABLE MatchEvents (
  MatchEventId INT IDENTITY PRIMARY KEY,
  MatchId INT NOT NULL,
  Minute TINYINT NULL,
  EventType NVARCHAR(10) NOT NULL,   -- GOAL
  ScorerPlayerId INT NOT NULL,
  AssistPlayerId INT NULL,
  CONSTRAINT FK_MatchEvents_Match FOREIGN KEY (MatchId) REFERENCES Matches(MatchId),
  CONSTRAINT FK_MatchEvents_Scorer FOREIGN KEY (ScorerPlayerId) REFERENCES Players(PlayerId),
  CONSTRAINT FK_MatchEvents_Assist FOREIGN KEY (AssistPlayerId) REFERENCES Players(PlayerId)
);

-- Substitutions table to support per-sub confirmation
CREATE TABLE Substitutions (
  SubstitutionId INT IDENTITY PRIMARY KEY,
  MatchId INT NOT NULL,
  SegmentNo TINYINT NOT NULL,            -- 2..4 (or 1..4 if you want)
  PositionCode NVARCHAR(2) NOT NULL,     -- '1'..'11'
  OutPlayerId INT NOT NULL,
  InPlayerId INT NOT NULL,
  IsConfirmed BIT NOT NULL DEFAULT 0,
  IsRejected BIT NOT NULL DEFAULT 0,
  DecisionMadeAt DATETIME2 NULL,
  CONSTRAINT FK_Sub_Match FOREIGN KEY (MatchId) REFERENCES Matches(MatchId),
  CONSTRAINT FK_Sub_Out FOREIGN KEY (OutPlayerId) REFERENCES Players(PlayerId),
  CONSTRAINT FK_Sub_In FOREIGN KEY (InPlayerId) REFERENCES Players(PlayerId),
  CONSTRAINT FK_Sub_Pos FOREIGN KEY (PositionCode) REFERENCES Positions(PositionCode)
);
