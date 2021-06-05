## General info
<p>Application that finds the best flying path  between airports considering corona epidemic state in each country.</p>

## Table of contents
* [General info](#general-info)
* [Goal of the project](#Goal-of-the-project)
* [Data providers](#Data-providers)
* [how does it work](#how-does-it-work)
* [Technologies](#technologies)
* [Screenshots](#Screenshots)
* [Project Status](#Project-Status)
* [Room for Improvement](#Room-for-Improvement)

## Goal of the project
<p>The goal was to create appliaction that finds fliyng path from one airport to another if there is no direct flight and also taking into care epidemic state in the world.</p>

## Data providers
<p>for flights/airports/cities data i used https://aviationstack.com/ api</p>
<p>for corona virus states in each country I used https://corona.lmao.ninja api</p>

## how does it work
<p>First appliaction asks user for information: airport departure, airport arrival, date, max number of changes between flights</p>
<p>then appliaction finds in database all flights from airport departure then all flights from these flights airports arrival, and so on recursively.</p>
<p>how many times? as many times as User prefers to change flights between flights</p>
<p> and finally appliaction makes graph from all flights(edges) and airports(vertex) and by using Dijsktra's alghorithm finds best path</p>



## Technologies
* C#
* ASP.NET Core 5.0
* Entity Framework core
* HTML&CSS
* JavaScript
* Leaflet js map library
* Bootstrap

## Screenshots
first view for geting input
![](https://github.com/JakubBehring/safe-routes/blob/main/safe%20routes/wwwroot/images/firstView.png)

path on map example 
![](https://github.com/JakubBehring/safe-routes/blob/main/safe%20routes/wwwroot/images/path.png)

map and path information
![](https://github.com/JakubBehring/safe-routes/blob/main/safe%20routes/wwwroot/images/pathInfo.png)


## Project Status
no longer working on it due to swap to other projects

## Room for Improvement
* improve alghorithm for finding paths
* finding more than one path



