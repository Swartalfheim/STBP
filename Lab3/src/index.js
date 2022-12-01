const RSA = require('./rsa.js');
const NodeRSA = require('node-rsa');
const key = new NodeRSA({ b: 1024 });
////////// Check
const message = 'Hello, World!';
const encrypted = key.encrypt(message, 'base64');
console.log('encrypted: ', encrypted);
const decrypted = key.decrypt(encrypted, 'utf8');
console.log('decrypted: ', decrypted);
// ///////

// Generate RSA keys
const keys = RSA.generate(1024);

console.log('Keys');
console.log('public:', keys.n.toString());
console.log('private:', keys.d.toString());

const encoded_message = RSA.encode(message);
const encrypted_message = RSA.encrypt(encoded_message, keys.n, keys.e);
const decrypted_message = RSA.decrypt(encrypted_message, keys.d, keys.n);
const decoded_message = RSA.decode(decrypted_message);

console.log('Message:', message);
console.log('Encoded:', encoded_message.toString());
console.log('Encrypted:', encrypted_message.toString());
console.log('Decrypted:', decrypted_message.toString());
console.log('Decoded:', decoded_message.toString());
console.log();
console.log('Correct?', message === decoded_message);
