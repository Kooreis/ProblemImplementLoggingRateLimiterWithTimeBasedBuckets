Here is a simple implementation of a logging rate limiter using time-based buckets in Java:

```java
import java.util.*;

public class Main {
    public static void main(String[] args) {
        Logger logger = new Logger();
        System.out.println(logger.shouldPrintMessage(1, "foo")); // returns true
        System.out.println(logger.shouldPrintMessage(2, "bar")); // returns true
        System.out.println(logger.shouldPrintMessage(3, "foo")); // returns false
        System.out.println(logger.shouldPrintMessage(8, "bar")); // returns false
        System.out.println(logger.shouldPrintMessage(10, "foo")); // returns false
        System.out.println(logger.shouldPrintMessage(11, "foo")); // returns true
    }
}

class Logger {
    private Map<String, Integer> msgMap;

    public Logger() {
        msgMap = new HashMap<>();
    }

    public boolean shouldPrintMessage(int timestamp, String message) {
        if (!msgMap.containsKey(message)) {
            msgMap.put(message, timestamp);
            return true;
        }

        Integer oldTimestamp = msgMap.get(message);
        if (timestamp - oldTimestamp >= 10) {
            msgMap.put(message, timestamp);
            return true;
        } else {
            return false;
        }
    }
}
```

This program creates a Logger class that keeps track of messages and the last time they were printed. The `shouldPrintMessage` method checks if a message should be printed based on the timestamp. If the message has not been printed in the last 10 seconds, it is printed and the timestamp is updated. If the message has been printed in the last 10 seconds, it is not printed.