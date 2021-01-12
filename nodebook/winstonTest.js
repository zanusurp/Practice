const winston = require('winston');
function timeStampFormat(){
    return moment().format('YYYY-MM-DD HH:mm:ss.SSS ZZ');
};
const logger = winston.createLogger({
  level: 'info',
  format: winston.format.json(),
  defaultMeta: { service: 'user-service' },
  transports: [
   
    new winston.transports.File({ name:'info-file',
    filename:'./log/server',
    datePattern:'_yyyy-MM-dd.log',
    colorize:false,
    maxsize:50000000,
    maxFiles:1000,
    level:'info',
    showLevel:true,
    json:false,
    timestamp: timeStampFormat }),
    new winston.transports.File({ filename: 'combined.log' }),
  ],
});

//
// If we're not in production then log to the `console` with the format:
// `${info.level}: ${info.message} JSON.stringify({ ...rest }) `
//
if (process.env.NODE_ENV !== 'production') {
  logger.add(new winston.transports.Console({
    format: winston.format.simple(),
  }));
}

module.exports = logger;