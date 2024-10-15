# VI Company Assessment
In this repository is my solution to your Backend Assessment.<br />
The reasoning and commentary can be found as comments within the code, to merge requests, and (if needed) in some commits.<br/>
Aside from that, I will describe what I did per each objective below:<br/>
### Objective 1 - Implement the constructor of Portfolio
In this objective, I am asked to process the transactions supplied to the Portfolio constructor into an actual list of instrument positions, owned by the user, and their balance after all the transactions.<br/>
<p>My first idea was to simply treat it as a conversion issue, and use LINQ to both calculate the balance, and count the positions. I initially wanted to do this in a single function, despite a mild Single Responsibility violation, thinking that using LINQ would make up for the readability loss, and having single logical pipeline would be better for performance than two.<p/><p>As I found out soon enough, the logic of handling balance and positions was different enough to negate any readability benefits of LINQ, and all I was left with was a long and barely readable function that did not work anyway.</p><p>Here, I decided to split the flows right after enumerating the array once - to prevent double enumeration later on, and implement balance and positions calculations as they should be - two different functionalities.</p><p>Coding-wise, only grind came after, and the details of how the functionalities work can be read from the code (and comments) itself.</p>

### Objective 2 - Replace DummyQuotesRepository with live data from Tickly
<p>To accomplish this one, I decided to reuse a pattern from my earlier projects:<br/>Fetch with HttpClient -> Decode into DTO using Newtonsoft -> Convert DTO to internal model.</p>
<p>For this approach, I have also put a ToQuotes() function within the DTO, which would take care of conversion, finishing up the DTO's responsibility of being a bridge between JSON response and usable objects.</p><p>With that, I have injected the repository into the HomeController instead of the dummy one, although I have conciously kept the dummy repository as it could be handy for testing later on.</p>

### Objective 3 - Refactor the solution
<p>For the refactoring, I chose the naming as my prey. The variables' names were rather inconsistent (especially with the class names), which immediately was adding to my confusion after reading the assessment objectives</p>
<p>The exact changes of the variables can be found as a description to the corresponding merge request.</p>
<p>While I understand that some of the names may be tied to specific terminology around the project, and I would absolutely check in with someone who knows if they actually are in a real environment, for the purposes of this assessment, I didn't do so to save the hassle for both you and me.</p><p>I do believe that the changes make the code much more understandable, especially for someone without prior knowledge of the project (just like myself several hours ago).</p>
