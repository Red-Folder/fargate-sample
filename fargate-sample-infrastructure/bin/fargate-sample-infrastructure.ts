#!/usr/bin/env node
import 'source-map-support/register';
import * as cdk from '@aws-cdk/core';
import { FargateSampleInfrastructureStack } from '../lib/fargate-sample-infrastructure-stack';

const app = new cdk.App();
new FargateSampleInfrastructureStack(app, 'FargateSampleInfrastructureStack');
