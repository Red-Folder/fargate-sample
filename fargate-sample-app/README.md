# Fargate Sample App
This is a DotNet Core sample application for demonstrating a pooling based application running within Fargate.

The application is written to simulate a long running application - it "fakes" an action every 3 seconds.  Randomly (1 in 10 chance) the action will result in a simulated hanging state.  This hanging state is used to demonstrate how, with the Docker Health Check, that Fargate can create a new instance of an unhealthy service.

## Health Check 
The application demonstrates a method of providing a Docker Health Check that can be exposed to an orchestrator services.

In the case of this sample, the Orchestrator is AWS Fargate - but the Health Check will work with any orchestrator that understands Docker Health Check.

The Health Check mechanism is fairly simple in this application;

It maintains a singleton "HealthMonitor" class which holds the last time that the monitored action "checked in".  That "HealthMonitor" is then used by a WebApi to return if the application is health (which in turn is used by the Docker Health Check method configured in the Dockerfile).  The WebApi will return Health all the while that the last "check in" was within the last ten seconds.

If the monitored action does not "check in" within the last 10 seconds, then the WebApi will return unhealthy.

The Docker Health Check is configured to check against the WebApi every 5 seconds.  If the WebApi returns unhealthy 3 times in a row, then the Docker Health Check will register the container as unhealthy.

## Build and deploy
This application uses Docker to build application image.

To build and deploy:

* `cd FargateSampleApp` Change directory to the sample app
* `docker build -t fargatesampleapp .` Build the application using Docker