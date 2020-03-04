# Fargate Sample
A sample polling style service hosted in AWS Fargate.

This sample is made up of:

* AWS Infrastructure using AWS CDK (Cloud Development Kit) - [more here](fargate-sample-infrastructure/README.md)
* Sample polling app using C# - [more here](fargate-sample-app/README.md)

## Steps to use
To use:

1. [Deploy the AWS ECR (Elastic Container Registry)](fargate-sample-infrastructure/README.md#deploy-the-registry-stack)
2. [Build and push the sample app to the AWS ECR](fargate-sample-app/README.md#build-and-deploy)
3. [Deploy a container using the sample app from the AWS ECR to AWS Fargate](fargate-sample-infrastructure/README.md#deploy-the-sample-app-stack)

## Clean up
[See the clean up instructions to remove the AWS resources](fargate-sample-infrastructure/README.md#clean-up)