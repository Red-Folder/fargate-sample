import * as cdk from '@aws-cdk/core';
import * as ecr from '@aws-cdk/aws-ecr';

export class FargateSampleRegistryStack extends cdk.Stack {
  constructor(scope: cdk.Construct, id: string, props?: cdk.StackProps) {
    super(scope, id, props);

    const registry = new ecr.Repository(this, 'Registry', {
      repositoryName: 'fargatesampleapp'
    });

    new cdk.CfnOutput(this, 'RegistryUrl', {
      exportName: 'RegistryUri',
      value: registry.repositoryUri
    });
  }
}
