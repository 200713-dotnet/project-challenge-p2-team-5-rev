ç
¨/Users/cvchavez2/Developer/VisualStudioCode/Revature/in-training/2007_13_dotnet/projects/project-challenge-p2-team-5-rev/BugTracker.Client/Controllers/HomeController.cs
	namespace

 	

BugTracker


 
.

 
Client

 
.

 
Controllers

 '
{ 
public 

class 
HomeController 
:  !

Controller" ,
{ 
private 
readonly 
ILogger  
<  !
HomeController! /
>/ 0
_logger1 8
;8 9
public 
HomeController 
( 
ILogger %
<% &
HomeController& 4
>4 5
logger6 <
)< =
{ 	
_logger 
= 
logger 
; 
} 	
public 
IActionResult 
Index "
(" #
)# $
{ 	
return 
View 
( 
) 
; 
} 	
public 
IActionResult 
Privacy $
($ %
)% &
{ 	
return 
View 
( 
) 
; 
} 	
[ 	
ResponseCache	 
( 
Duration 
=  !
$num" #
,# $
Location% -
=. /!
ResponseCacheLocation0 E
.E F
NoneF J
,J K
NoStoreL S
=T U
trueV Z
)Z [
][ \
public   
IActionResult   
Error   "
(  " #
)  # $
{!! 	
return"" 
View"" 
("" 
new"" 
ErrorViewModel"" *
{""+ ,
	RequestId""- 6
=""7 8
Activity""9 A
.""A B
Current""B I
?""I J
.""J K
Id""K M
??""N P
HttpContext""Q \
.""\ ]
TraceIdentifier""] l
}""m n
)""n o
;""o p
}## 	
}$$ 
}%% ÿ
«/Users/cvchavez2/Developer/VisualStudioCode/Revature/in-training/2007_13_dotnet/projects/project-challenge-p2-team-5-rev/BugTracker.Client/Controllers/ProductController.cs
	namespace

 	

BugTracker


 
.

 
Client

 
.

 
Controllers

 '
{ 
[ 
Route 

(
 
$str #
)# $
]$ %
public 

class 
ProductController "
:# $

Controller% /
{ 
public 
IActionResult 
Product $
($ %
)% &
{ 	
return 
View 
( 
) 
; 
} 	
} 
} ú
¨/Users/cvchavez2/Developer/VisualStudioCode/Revature/in-training/2007_13_dotnet/projects/project-challenge-p2-team-5-rev/BugTracker.Client/Controllers/UserController.cs
	namespace

 	

BugTracker


 
.

 
Client

 
.

 
Controllers

 '
{ 
[ 
Route 

(
 
$str #
)# $
]$ %
public 

class 
UserController 
:  !

Controller" ,
{ 
public 
IActionResult 
UserPage %
(% &
)& '
{ 	
return 
View 
( 
) 
; 
} 	
} 
} “
£/Users/cvchavez2/Developer/VisualStudioCode/Revature/in-training/2007_13_dotnet/projects/project-challenge-p2-team-5-rev/BugTracker.Client/Models/ErrorViewModel.cs
	namespace 	

BugTracker
 
. 
Client 
. 
Models "
{ 
public 

class 
ErrorViewModel 
{ 
public 
string 
	RequestId 
{  !
get" %
;% &
set' *
;* +
}, -
public		 
bool		 
ShowRequestId		 !
=>		" $
!		% &
string		& ,
.		, -
IsNullOrEmpty		- :
(		: ;
	RequestId		; D
)		D E
;		E F
}

 
} ²
¢/Users/cvchavez2/Developer/VisualStudioCode/Revature/in-training/2007_13_dotnet/projects/project-challenge-p2-team-5-rev/BugTracker.Client/Models/UserViewModel.cs
	namespace 	

BugTracker
 
. 
Client 
. 
Models "
{ 
} ‘
•/Users/cvchavez2/Developer/VisualStudioCode/Revature/in-training/2007_13_dotnet/projects/project-challenge-p2-team-5-rev/BugTracker.Client/Program.cs
	namespace

 	

BugTracker


 
.

 
Client

 
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
} ê
•/Users/cvchavez2/Developer/VisualStudioCode/Revature/in-training/2007_13_dotnet/projects/project-challenge-p2-team-5-rev/BugTracker.Client/Startup.cs
	namespace 	

BugTracker
 
. 
Client 
{ 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. #
AddControllersWithViews ,
(, -
)- .
;. /
} 	
public 
void 
	Configure 
( 
IApplicationBuilder 1
app2 5
,5 6
IWebHostEnvironment7 J
envK N
)N O
{ 	
if   
(   
env   
.   
IsDevelopment   !
(  ! "
)  " #
)  # $
{!! 
app"" 
."" %
UseDeveloperExceptionPage"" -
(""- .
)"". /
;""/ 0
}## 
else$$ 
{%% 
app&& 
.&& 
UseExceptionHandler&& '
(&&' (
$str&&( 5
)&&5 6
;&&6 7
app(( 
.(( 
UseHsts(( 
((( 
)(( 
;(( 
})) 
app++ 
.++ 
UseStaticFiles++ 
(++ 
)++  
;++  !
app-- 
.-- 

UseRouting-- 
(-- 
)-- 
;-- 
app// 
.// 
UseAuthorization//  
(//  !
)//! "
;//" #
app11 
.11 
UseEndpoints11 
(11 
	endpoints11 &
=>11' )
{22 
	endpoints33 
.33 
MapControllerRoute33 ,
(33, -
name44 
:44 
$str44 #
,44# $
pattern55 
:55 
$str55 E
)55E F
;55F G
}66 
)66 
;66 
}77 	
}88 
}99 