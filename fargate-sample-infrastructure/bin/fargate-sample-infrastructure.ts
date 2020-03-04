#!/usr/bin/env node
import 'source-map-support/register';
import * as cdk from '@aws-cdk/core';
import { FargateSampleRegistryStack } from '../lib/fargate-sample-registry-stack';
import { FargateSampleAppStack } from '../lib/fargate-sample-app-stack';

const addTags = (stack: cdk.Construct, stackName: string, ) => {
    cdk.Tag.add(stack, 'Name', stackName);
    cdk.Tag.add(stack, 'Environment', 'dev');
    cdk.Tag.add(stack, 'Product', 'Fargate Sample');
    cdk.Tag.add(stack, 'Description', 'A sample application to demonstrate using AWS Fargate for a reliable log lived service.')
};

const app = new cdk.App();

const repositoryStack = new FargateSampleRegistryStack(app, 'FargateSampleRegistryStack');
addTags(repositoryStack, "Fargate Sample - Registry");

const appStack = new FargateSampleAppStack(app, 'FargateSampleAppStack');
addTags(appStack, "Fargate Sample - Application");


