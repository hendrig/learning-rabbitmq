# Learning RabbitMQ

This is a repository to host my studies on RabbitMQ.

I'm following the path that you can find [here](https://www.rabbitmq.com/getstarted.html).

## Running RabbitMQ

To run RabbitMQ I used `docker` on my machine.
I simply ran the following command:
```
docker run -d --hostname my-rabbit --name rabbit13 -p 8080:15672 -p 5672:5672 -p 25676:25676 rabbitmq:3-management
```

## The "Steps"

Each step of the tutorial have its own folder.
- [Step 1: "Hello World!"](Step1/README.md)
- [Step 2: "Work Queues"](Step2/README.md)