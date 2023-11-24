type Coach = {
    Name: string
    formerPlayer: bool
}

type Stats = {
    Wins: int
    Losses: int
}

type Team = {
    Name: string
    Coach: Coach
    Stats: Stats
}

let teams = [
    { Name= "Dallas Mavericks"; Coach ={Name="Jason Kidd"; formerPlayer=true}; Stats= {Wins= 1747; Losses= 1714} }
    { Name= "Indiana Pacers"; Coach ={Name="Rick Carlisle"; formerPlayer=true}; Stats= {Wins= 1883; Losses= 1903} }
    { Name= "Houston Rockets"; Coach ={Name="Ime Udoka"; formerPlayer=false}; Stats= {Wins= 2328; Losses= 2196} }
    { Name= "Toronto Raptors"; Coach ={Name="Ime Udoka"; formerPlayer=false}; Stats= {Wins= 1071; Losses= 1157} }
    { Name= "Los Angeles Lakers"; Coach ={Name="Ime Udoka"; formerPlayer=false}; Stats= {Wins= 3503; Losses= 2419} }
]


for team in teams do
    printfn "Team: %s" team.Name
    printfn "Coach: %s, Former Player: %b" team.Coach.Name team.Coach.formerPlayer
    printfn "Wins: %d, Losses: %d" team.Stats.Wins team.Stats.Losses
    printfn "-----------------------------"

    let successPercentage team =
    let totalGames = float (team.Stats.Wins + team.Stats.Losses)
    if totalGames = 0.0 then
        0.0 
    else
        (float team.Stats.Wins / totalGames) * 100.0

let successPercentages = List.map successPercentage teams

 Print information about success percentages
printfn "Success Percentages:"
List.iter2 (fun team percentage ->
    printfn "Team: %s, Success Percentage: %.2f%%" team.Name percentage
) teams successPercentages

type Cuisine =
    | Korean
    | Turkish

type MovieType =
    | Regular
    | IMAX
    | DBOX
    | RegularWithSnacks
    | IMAXWithSnacks
    | DBOXWithSnacks

type Activity =
    | BoardGame
    | Chill
    | Movie of MovieType  
    | Restaurant of Cuisine  
    | LongDrive of int * float  

let clculteBudget(activity: Activity) =
    match activity with
    | BoardGame -> 0.0
    | Chill -> 0.0
    | Movie movieType ->
        match movieType with
        | Regular -> 12.0
        | IMAX -> 17.0
        | DBOX -> 20.0
        | RegularWithSnacks -> 17.0  
        | IMAXWithSnacks -> 22.0    
        | DBOXWithSnacks -> 25.0    
    | Restaurant cuisine ->
        match cuisine with
        | Korean -> 70.0
        | Turkish -> 65.0
    | LongDrive (distance, fuelCharge) -> float distance * fuelCharge

let activity = Movie DBOXWithSnacks
let budget = clculteBudget activity
printfn "The budget for DBOX movie with Snacks will be: %.2f CAD" budget
