# BallClickingGame
ENG - Simple ball clicking game with the ball moving around the screen and collecting points with clicking it. Implemented in ASP.NET Windows Forms in programming language C# using document serialization and Entity Framework with Repository pattern if you want to work with database.

MK - 
1.Опис и цел на апликацијата:
Апликацијата е едноставна игра која се игра со кликање на топче што се движи низ екранот за време од 30 секунди. Целта е да соберете што е можно повеќе поени. Поените се пресметуваат како бројот на кликнувања на топчето одземени од бројот на промашувања на топчето.

2.Упатство за користење
2.1 Play game
На почетниот прозорец имаме можност да избереме почеток на играта(Play Game) или да ја видиме листата со поени (Scoreboard).

2.2 Scoreboard 
При клик на копчето Scoreboard првично се прикажуваат 10те најдобри играчи според бројот на постигнати поени, постои опција да се видат и останатите играчи најдобри 1000 играчи со притискање на копчето View All.

2.3 Save score 
При изминување на времето од 30 секунди се генерира прозорец кој ви нуди можност да го зачувате вашиот резултат со ваше име кое мора да биде поголемо од 3 и помало од 25 каракетри со притискање на копчето Save од формата. Имињата може се повторуваат, односно еден играч.


Податоците се сериализирани и се достапни и послем исклучување на играта. Исто така постои пожност за користење на База на податоци со користење на Entity Framework при што се користи Repository pattern. Кодот за функционалност со База на податоци е имплементиран и коментиран, но потребно е да има инсталирано SQLServer на вашата машина.

3.Претставување на проблемот
3.1 Податочни структури
3.1.1 Модели (класи)
Податоците и функциите за топчето се чуваат во класата Ball, додека топчето е представено на сцена која е имплементирана во класата BallScene. Во класата Player се чуваат информации за податоци и функции кои се користат при сериализација и запишување на објектот во базата на податоци, додека класата PlayersDoc содржи функционалност која се користи при сериализација на документот, односно Scoreboard листата и манипулација со играчите за време на користење на апликацијата.
Базата на податоци со коритење на EntityFramework е имплементирана во класата BallClickingGameDatabase, додека објект од неа се креира и со неа се манипулира во складиштето на играчи(Players repository).
3.1.2 Форми 
	Во апликацијата се користат три форми, GameForm за главна манипулацијата и две помошни форми SaveScoreForm и ScoreboardForm за зачувување и приказ на играчите и нивните поени.

4.Некои методи, алгоритми и функционалости
Move() - метода за движење на топчето низ формата со одбивање од рабовите на истата.
GetTop10Players() – метода за сортирање и земање на најдобрите 10 играчи по опаѓачки редослед користејќи ја LINQ Lambda expression синтаксата. Некои пропертија во класите се документирани со <summary> xml тагови за полесно користење на класите во нивна употреба при понатамошна изработка на проектот.

Апликацијата и класите се отворени за проширување (Reusable) при понатамошно развивање на играта, односно би можело да се прошири апликацијата за играње во повеќе модови на пример мод со custom time на играње, повеќе топчиња кои би се движеле по екранот, секое од тие топчиња би носело различен број на поени и би се движело со различна брзина со креирање на нови класи и наследување од основите досега креирани класи при стандардниот едноставен мод. 
Проектот е достапен на: Dropbox - https://www.dropbox.com/sh/52m5v8bjz2g4y23/AACcpLvQ1eiUfkwoz4o3Qy3Ya?dl=0
GitHub - https://github.com/fpipe/BallClickingGame

