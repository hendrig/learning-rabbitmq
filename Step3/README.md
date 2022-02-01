# Step 3 - Publish/Subscribe

Here we introduce the idea that the producer do not add a message on the queue directly. The producer send a message to an `exchange`. The exchange have a type.

There are a few types of exchange: `direct`, `topic`, `header` and `fanout`.

In this tutorial, we used the last type, the `fanout`.