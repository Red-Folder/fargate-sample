#!/usr/bin/env node
import 'source-map-support/register';
import * as cdk from '@aws-cdk/core';
import { FargateSampleInfrastructureStack } from '../lib/fargate-sample-infrastructure-stack';
import { FargateSampleAppStack } from '../lib/fargate-sample-app-stack';

const addTags = (stack: cdk.Construct, stackName: string, ) => {
    cdk.Tag.add(stack, 'Name', stackName);
    cdk.Tag.add(stack, 'ENVIRONMENT', 'dev');
    cdk.Tag.add(stack, 'PRODUCT', 'Fargate Sample');
    cdk.Tag.add(stack, 'DESCRIPTION', 'A sample application to demonstrate using AWS Fargate for a reliable log lived service.')
};

const app = new cdk.App();

const repositoryStack = new FargateSampleInfrastructureStack(app, 'FargateSampleInfrastructureStack');
addTags(repositoryStack, "Fargate Sample - Repository");

const appStack = new FargateSampleAppStack(app, 'FargateSampleAppStack');
addTags(appStack, "Fargate Sample - Application");


