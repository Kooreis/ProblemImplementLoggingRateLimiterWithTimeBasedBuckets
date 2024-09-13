Here is a Python console application that implements a logging rate limiter with time-based buckets. This application uses a dictionary to store the timestamps of the logs and a time window to limit the rate of logging.

```python
import time

class Logger:
    def __init__(self, rate_limit):
        self.rate_limit = rate_limit
        self.logs = {}

    def should_print_message(self, message, timestamp):
        if message not in self.logs:
            self.logs[message] = timestamp
            return True

        if timestamp - self.logs[message] >= self.rate_limit:
            self.logs[message] = timestamp
            return True

        return False

def main():
    logger = Logger(10)
    print(logger.should_print_message("test", 1)) # returns True
    time.sleep(1)
    print(logger.should_print_message("test", 2)) # returns False
    time.sleep(10)
    print(logger.should_print_message("test", 12)) # returns True

if __name__ == "__main__":
    main()
```

In this application, the `Logger` class is initialized with a `rate_limit` which is the time window for limiting the rate of logging. The `should_print_message` method checks if a message should be printed based on the `rate_limit`. If the message is not in the logs or if the difference between the current timestamp and the last logged timestamp for the message is greater than or equal to the `rate_limit`, the message is logged and the method returns `True`. Otherwise, the method returns `False`.

The `main` function creates a `Logger` instance with a `rate_limit` of 10 seconds and tests the `should_print_message` method with a "test" message and different timestamps. The `time.sleep` function is used to simulate the passage of time.