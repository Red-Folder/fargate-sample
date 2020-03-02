# AWS Infrastructure for a Fargate Sample Application
This project uses the [AWS CDK (Cloud Development Kit)](https://docs.aws.amazon.com/cdk/latest/guide/home.html) to provide infrastructure-as-code.

The project sets up the necessary AWS infrastructure to support a Fargate sample demo.

To support this the project sets up:

* AWS ECR (Elastic Container Registry)

*WORK IN PROGRESS*

## To Deploy
Run:

* `npm run build` compile typescript to js
* `cdk deploy --profile {profile-name}` deploy this stack to the AWS account/ region as specified in your profile (omit profile if you want to deploy to your default AWS account/ region)
* `cdk destroy --profile {profile-name}` destroys this stack in AWS.  This will remove all parts of the stack and should only be used to clean up once completed.
