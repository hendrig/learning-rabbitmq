# Step 2 - Work Queues

This one is more interesting.
In this tutorial we create a worker that consumes and simulates time being spended on a task.
I did a slight change in order to test it with multiple messages being sent at the same time, with multiple timespans.

According to the tutorial, the `NewTask` class will send a message, and if this message have a `.` character, it means that the consumer will wait 1 second to finally "ACK" it. Each `.` means 1 second, so a message with 10 "dots" will take 10 seconds to be processed by the `Worker` program.