import { expect as expectCDK, matchTemplate, MatchStyle } from '@aws-cdk/assert';
import * as cdk from '@aws-cdk/core';
import FargateSampleInfrastructure = require('../lib/fargate-sample-infrastructure-stack');

test('Empty Stack', () => {
    const app = new cdk.App();
    // WHEN
    const stack = new FargateSampleInfrastructure.FargateSampleInfrastructureStack(app, 'MyTestStack');
    // THEN
    expectCDK(stack).to(matchTemplate({
      "Resources": {}
    }, MatchStyle.EXACT))
});
