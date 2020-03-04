# Fargate Sample App
This is a DotNet Core sample application for demonstrating a polling based application running within AWS Fargate.

The application is written to simulate a long running application - it "fakes" an action every 3 seconds.  Randomly (1 in 10 chance), the application will fail.

There are two possible failure states - it crashes (and terminates) or it hangs for 2 minutes.

The hanging state is used to demonstrate how, with the Docker Health Check, that AWS Fargate can create a new instance of an unhealthy service.

## Health Check 
The application demonstrates a method of providing a Docker Health Check that can be exposed to an orchestrator services.

In the case of this sample, the Orchestrator is AWS Fargate - but the Health Check will work with any orchestrator that can integrate into with the /api/Health endpoint or the Docker Health Check.

The Health Check mechanism is fairly simple in this application;

It maintains a singleton "HealthMonitor" class which holds the last time that the monitored action "checked in".  That "HealthMonitor" is then used by a WebApi to return if the application is health (which in turn is used by the Docker Health Check method configured in the Dockerfile).  The WebApi will return Health all the while that the last "check in" was within the last ten seconds.

If the monitored action does not "check in" within the last 10 seconds, then the WebApi will return unhealthy.

The Docker Health Check is configured to check against the WebApi every 5 seconds.  If the WebApi returns unhealthy 3 times in a row, then the Docker Health Check will register the container as unhealthy.

## Build and deploy
Before deploying, ensure that the AWS ECR (Elastic Container Registry) has been created using the [fargate-sample-infrastructure](../fargate-sample-infrastructure/README.md).  Instructions below assume that the AWS ECR has been created and you have the full Uri.

To build and deploy (*Note:* {AWS ECR Uri} should be replaced with the full Uri of your AWS ECR instance):

* `cd FargateSampleApp` Change directory to the sample app
* `(Get-ECRLoginCommand).Password | docker login --username AWS --password-stdin {AWS ECR Uri}` Configured Docker with the credentials of your AWS ECR instance.
* `docker build -t fargatesampleapp:latest .` Build the application using Docker
* `docker tag fargatesampleapp:latest {ECR Url}:latest` Tags the application ready for push.  
* `docker push {ECR Url}:latest` Pushes the image to ECR.
