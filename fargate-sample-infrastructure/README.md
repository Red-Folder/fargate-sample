# AWS Infrastructure for a Fargate Sample Application
This project uses the [AWS CDK (Cloud Development Kit)](https://docs.aws.amazon.com/cdk/latest/guide/home.html) to provide infrastructure-as-code.

The project sets up the necessary AWS infrastructure to support a Fargate sample demo.

To support this the project sets up:

* AWS ECR (Elastic Container Registry)

*WORK IN PROGRESS*

## To Deploy
Run:

* `npm run build` compile typescript to js.
* `cdk deploy --profile {profile-name}` deploy this stack to the AWS account/ region as specified in your profile (omit profile if you want to deploy to your default AWS account/ region).
* `cdk destroy --profile {profile-name}` destroys this stack in AWS.  This will remove all parts of the stack and should only be used to clean up once completed. The `destroy` command does not remove all parts of the stack.  By default it will leave the ECR (Elastic Container Registry) which must be removed manually.

*Note:* The `deploy` will output ECR Repository Url - this will be needed for the deployment of the [Sample Application](../fargate-sample-infrastructure/README.md).
