using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


List<Instruction> instructions1 = new List<Instruction>();
List<Instruction> instructions2 = new List<Instruction>();
List<Instruction> instructions3 = new List<Instruction>();
List<Instruction> instructions4 = new List<Instruction>();


List<string> instText1 = new List<string>{
  "Welcome to the Git Lesson! I hope that you are going to learn a lot! You will be inserting code where it says person 1!",
  "Start by cloning the repo: https://github.com/TeamParadise/GitLesson",
  "You are responsible for also creating the develop branch. Do this by running \'git checkout -b develop\'",
  "Push that branch to the remote repo by running \'git push -u origin develop\'",
  "Make a new branch titled user/<yourName>/feature1, please ensure this branch is based off of the develop branch (this can be done via the command line, or in github and then pull the branch via a fetch and checkout.)",
  "Ensure your newly created branch is checked out using \'git checkout <branchName>\'",
  "Under the line with #Person 1, add a for-loop to print out the numbers 1-10",
  "Commit your changes to git either through the VS Code Source control window or by using the following commands:",
  "\'git add .\'",
  "\'git commit -m \"<Message describing your commit\"\'>",
  "\'git push\' (it may give you a new command to run to send your branch remote if you didn't create it in github)",
  "Make a Pull Request in github, pulling your changes into the develop branch adding the other participants as required reviewers.",
  "You are now finished. Person 2 may start.",
};

List<string> instText2 = new List<string>{
  "Welcome to the Git Lesson! I hope that you are going to learn a lot! You will be inserting code where it says person 2!",
  "Start by cloning the repo: https://github.com/TeamParadise/GitLesson",
  "Make a new branch titled user/<yourName>/feature1, please ensure this branch is based off of the develop branch (this can be done via the command line, or in github and then pull the branch via a fetch and checkout.)",
  "Under the line with #Person 2, create a variable with any integer value you choose, then implement an if statement checking whether the number is odd or even, printing \"odd\" or \"even\" accordingly.",
  "Commit your changes to git either through the VS Code Source control window or by using the following commands:",
  "\'git add .\'",
  "\'git commit -m \"<Message describing your commit\"\'>",
  "\'git push\'",
  "Make a Pull Request in github, pulling your changes into the develop branch adding the other participants as required reviewers.",
  "You are now finished. Person 3 may start.",
};

List<string> instText3 = new List<string>{
  "Welcome to the Git Lesson! I hope that you are going to learn a lot! You will be inserting code where it says person 3!",
  "Start by cloning the repo: https://github.com/TeamParadise/GitLesson",
  "Make a new branch titled user/<yourName>/feature1, please ensure this branch is based off of the develop branch (this can be done via the command line, or in github and then pull the branch via a fetch and checkout.)",
  "Wait for Person 1 and 2 to finish",
  "Make sure your computer knows about the remote changes by running \'git fetch\' and \'git pull develop\'",
  "Rebase your branch on the develop branch by ensuring you are checked out on your branch and by typing \'git rebase develop\'",
  "Under the line with #Person 1 and Person 3, change the for loop to end at 20 instead of 10.",
  "Commit your changes to git either through the VS Code Source control window or by using the following commands:",
  "\'git add .\'",
  "\'git commit -m \"<Message describing your commit\"\'>",
  "\'git push\'",
  "Make a Pull Request in github, pulling your changes into the develop branch adding the other participants as required reviewers.",
  "You are now finished. Person 4 may start.",
};

List<string> instText4 = new List<string>{
  "Welcome to the Git Lesson! I hope that you are going to learn a lot! You will be inserting code where it says person 4! (You have the hardest part!)",
  "Start by cloning the repo: https://github.com/TeamParadise/GitLesson",
  "Make a new branch titled: user/<yourName>/feature1, please ensure this branch is based off of the develop branch (this can be done via the command line, or in github and then pull the branch via a fetch and checkout.)",
  "Instead of rebasing, you will be creating merge conflicts! You will need to resolve them after they happen.",
  "WAIT FOR ALL OTHER PEOPLE TO FINISH, WE WILL SHARE YOUR SCREEN AND WALK THROUGH THE PROCESS.",
  "Under the line with #Person 2, create a variable with any integer value you choose, then implement an if statement checking whether the number is divisble by 3 or not , printing \'div by 3\' or \'not div by 3\' accordingly.",
  "Commit your changes to git either through the VS Code Source control window or by using the following commands:",
  "\'git add .\'",
  "\'git commit -m \"<Message describing your commit\"\'>",
  "\'git push\'",
  "Make a Pull Request in github, pulling your changes into the develop branch adding the other participants as required reviewers.",
  "In github, you should see on your pull request that there are merge conflicts, there are lots of tools to resolve these conflicts, but for simplicity, we will resolve them in github's editor.",
  "Click the resolve conflicts button",
  "You will see a red bar next to the section with conflicts. at the top of this section will be a set of \'<<<<<<<<\', then in the middle a set of \'=======\' and at the bottom another \'<<<<<<\'",
  "The \'<<<<<<\' are labeled with which branch they are from, delete the git artifacts as well as the content of the branch you would like to get rid of.",
  "Click mark as resolved.",
  "Click commit merge",
  "Git will recheck for merge conflicts. It will say ready to merge and you will wait for approval from all people that need to accept",
  "Congrats, you are finished."
};


int i = 0;

foreach(string inst in instText1){
  instructions1.Add(new Instruction(instText1[i], i));
  i++;
}
i = 0;
foreach(string inst in instText2){
  instructions2.Add(new Instruction(instText2[i], i));
  i++;
}
i = 0;
foreach(string inst in instText3){
  instructions3.Add(new Instruction(instText3[i], i));
  i++;
}
i = 0;
foreach(string inst in instText4){
  instructions4.Add(new Instruction(instText4[i], i));
  i++;
}



var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5001); // Listen on port 5000
});
var app = builder.Build();



app.MapGet("/", (HttpContext context) =>{
  return context.Response.WriteAsync("You got Hacked by Gatlin");
});

app.MapGet("/instructions/1", (HttpContext context) => {


  var json = JsonSerializer.Serialize(instructions1, new JsonSerializerOptions
    {
        WriteIndented = true, // Makes the JSON nicely formatted with indentation
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    });

    var response = Results.Ok(json);
    // Set the "Content-Type" header to "application/json"
    context.Response.Headers.Add("Content-Type", "application/json");
    

    // Write the JSON data to the response
    return context.Response.WriteAsync(json);
});

app.MapGet("/instructions/2", (HttpContext context) => {
  var json = JsonSerializer.Serialize(instructions2, new JsonSerializerOptions
    {
        WriteIndented = true, // Makes the JSON nicely formatted with indentation
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    });

    var response = Results.Ok(json);
    // Set the "Content-Type" header to "application/json"
    context.Response.Headers.Add("Content-Type", "application/json");

    // Write the JSON data to the response
    return context.Response.WriteAsync(json);
});

app.MapGet("/instructions/3", (HttpContext context) => {
  var json = JsonSerializer.Serialize(instructions3, new JsonSerializerOptions
    {
        WriteIndented = true, // Makes the JSON nicely formatted with indentation
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    });

    var response = Results.Ok(json);
    // Set the "Content-Type" header to "application/json"
    context.Response.Headers.Add("Content-Type", "application/json");

    // Write the JSON data to the response
    return context.Response.WriteAsync(json);
});

app.MapGet("/instructions/4", (HttpContext context) => {
  var json = JsonSerializer.Serialize(instructions4, new JsonSerializerOptions
    {
        WriteIndented = true, // Makes the JSON nicely formatted with indentation
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    });

    var response = Results.Ok(json);
    // Set the "Content-Type" header to "application/json"
    context.Response.Headers.Add("Content-Type", "application/json");

    // Write the JSON data to the response
    return context.Response.WriteAsync(json);
});

app.Run();



