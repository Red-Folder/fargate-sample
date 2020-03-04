# AWS Infrastructure for a Fargate Sample Application
This project uses the [AWS CDK (Cloud Development Kit)](https://docs.aws.amazon.com/cdk/latest/guide/home.html) to provide infrastructure-as-code.

The project sets up the necessary AWS infrastructure to support a Fargate sample demo.

To support this the project is made up of two stacks:

* FargateSampleRegistryStack - creates an AWS ECR (Elastic Container Registry)
* FargateSampleAppStack - creates an AWS Fargate instance using the [Sample App](../fargate-sample-infrastructure/README.md)

## Deploy the Registry Stack
Run:

* `npm run build` compile typescript to js.
* `cdk deploy FargateSampleRegistryStack --profile {profile-name}` deploy this stack to the AWS account/ region as specified in your profile (omit profile if you want to deploy to your default AWS account/ region).

*Note:* The `deploy` will output the AWS ECR Url - this will be needed for the deployment of the [Sample Application](../fargate-sample-infrastructure/README.md).


## Deploy the Sample App Stack
*Note:* Ensure that the [Sample Application](../fargate-sample-infrastructure/README.md) has been built and pushed to the AWS ECR first.

Run:

* `npm run build` compile typescript to js.
* `cdk deploy FargateSampleAppStack --profile {profile-name}` deploy this stack to the AWS account/ region as specified in your profile (omit profile if you want to deploy to your default AWS account/ region).

## Clean up
To remove all AWS resources:

* `cdk destroy FargateSampleAppStack --profile {profile-name}`
* `cdk destroy FargateSampleRegistryStack --profile {profile-name}` 
* Manually remove the AWS ECR (Elastic Container Registry) via the Portal/ CLI.

*Note:* `destroy` will not remove the AWS ECR - thus this needs to be done manually.
