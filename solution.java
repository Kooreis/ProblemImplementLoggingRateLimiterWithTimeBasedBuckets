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