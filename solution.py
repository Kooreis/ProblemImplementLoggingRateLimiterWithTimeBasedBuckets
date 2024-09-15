class Logger:
    def __init__(self, rate_limit):
        self.rate_limit = rate_limit
        self.logs = {}