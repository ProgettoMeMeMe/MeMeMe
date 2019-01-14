# MeMeMe
Progetto <b>MeMeMe</b> 2014 <br/>
Randomized controlled trial of metformin and dietary restriction to prevent age-related morbid events in people with metabolic syndrome
Principal Investigator: Franco Berrino, MD 
Host Institution: Fondazione IRCCS Istituto Nazionale dei Tumori - Milano (Italy)

## Getting Started

### Prerequisites
DB: Micrsosft Sql Server 2014 express (or never)
Microsoft Visual Studio 2014 (or newer), framework .NET Framework 4.5 (or never)

### Installing
First you need to create the database. It is possible alternatively to restore the database without minimal data or create a new empty dabase which will subsequently o be populated by users and randomization list.
If you want to proceed with restore
<ol>
  <li>Open SQL Server Management Studio  </li> 
  <li>Select server istanze and restore MeMeMe/App_Data/MeMeMeAudit.bak</li>
</ol>
If you want to proceed with use scrips
<ol>
  <li>Open SQL Server Management Studio</li>
  <li>Execute script CreateMeMeMe.sql</li> 
  <li>Execute script CreateUserAndRandomizationList.sql</li> 
</ol>
Before coplete restore DB MeMeMe, 
<ol>
  <li>Open project in Visual Studio and configure connection parameters in the web.config file</li>
  <li>Start project from visual studio and connect login page with user: TestUser01 pwd: J8d(Ah1.F17182gH</li>
</ol>
