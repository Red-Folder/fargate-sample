import * as cdk from '@aws-cdk/core';
import ec2 = require("@aws-cdk/aws-ec2");
import ecs = require("@aws-cdk/aws-ecs");
import ecr = require("@aws-cdk/aws-ecr");
import { Duration } from '@aws-cdk/core';


export class FargateSampleAppStack extends cdk.Stack {
    constructor(scope: cdk.Construct, id: string, props?: cdk.StackProps) {
        super(scope, id, props);

        const repository = ecr.Repository.fromRepositoryName(this, "Repository", "fargatesampleapp");

        const vpc = new ec2.Vpc(this, "Vpc", {
            maxAzs: 2
        });

        const cluster = new ecs.Cluster(this, "ElasticContainerService", {
            vpc: vpc,
            containerInsights: true
        });

        const taskDefinition = new ecs.FargateTaskDefinition(this, "TaskDefinition");
        taskDefinition.addContainer('SampleApp', {
            image: ecs.ContainerImage.fromEcrRepository(repository, "1.0"),
            cpu: 256,
            memoryLimitMiB: 512,
            logging: ecs.LogDrivers.awsLogs({
                streamPrefix: "FargateSample"
            }),
            healthCheck: {
                command: [ "CMD-SHELL", "curl -f http://localhost:8100/api/Health || exit 1" ],
                interval: Duration.seconds(5),
                timeout: Duration.seconds(3),
                retries: 3
            }
        });

        new ecs.FargateService(this, "Service", {
            cluster: cluster,
            taskDefinition: taskDefinition,
            desiredCount: 1
        });
    }
}
