œ
¢/Users/cvchavez2/Developer/VisualStudioCode/Revature/in-training/2007_13_dotnet/projects/project-challenge-p2-team-5-rev/BugTracker.Storing/BugTrackerDbContext.cs
	namespace 	

BugTracker
 
. 
Storing 
{ 
public 

class 
BugTrackerDbContext $
:% &
	DbContext' 0
{ 
} 
}		 “
–/Users/cvchavez2/Developer/VisualStudioCode/Revature/in-training/2007_13_dotnet/projects/project-challenge-p2-team-5-rev/BugTracker.Storing/Program.cs
	namespace

 	

BugTracker


 
.

 
Storing

 
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
} Ý
–/Users/cvchavez2/Developer/VisualStudioCode/Revature/in-training/2007_13_dotnet/projects/project-challenge-p2-team-5-rev/BugTracker.Storing/Startup.cs
	namespace 	

BugTracker
 
. 
Storing 
{ 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. 
AddControllers #
(# $
)$ %
;% &
services 
. 
AddDbContext !
<! "
BugTrackerDbContext" 5
>5 6
(6 7
options7 >
=>? A
{ 
options   
.   
UseSqlServer   $
(  $ %
Configuration  % 2
.  2 3
GetConnectionString  3 F
(  F G
$str  G N
)  N O
)  O P
;  P Q
}!! 
)!! 
;!! 
services"" 
."" 
AddSwaggerGen"" "
(""" #
)""# $
;""$ %
}## 	
public&& 
void&& 
	Configure&& 
(&& 
IApplicationBuilder&& 1
app&&2 5
,&&5 6
IWebHostEnvironment&&7 J
env&&K N
)&&N O
{'' 	
if(( 
((( 
env(( 
.(( 
IsDevelopment(( !
(((! "
)((" #
)((# $
{)) 
app** 
.** %
UseDeveloperExceptionPage** -
(**- .
)**. /
;**/ 0
}++ 
app// 
.// 

UseRouting// 
(// 
)// 
;// 
app11 
.11 

UseSwagger11 
(11 
)11 
;11 
app22 
.22 
UseSwaggerUI22 
(22 
options22 $
=>22% '
{33 
options44 
.44 
SwaggerEndpoint44 '
(44' (
$str44( B
,44B C
$str44D H
)44H I
;44I J
}55 
)55 
;55 
app77 
.77 
UseAuthorization77  
(77  !
)77! "
;77" #
app99 
.99 
UseEndpoints99 
(99 
	endpoints99 &
=>99' )
{:: 
	endpoints;; 
.;; 
MapControllers;; (
(;;( )
);;) *
;;;* +
}<< 
)<< 
;<< 
}== 	
}>> 
}?? 