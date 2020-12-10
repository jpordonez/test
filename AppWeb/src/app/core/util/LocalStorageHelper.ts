export class LocalStorageHelper {


  static get(key: string):any {

    let value = localStorage.getItem(key);
    if (!value) {
      return null;
    }

    let value1 = this.decode(value);
    if (this.isValid(value1)) {
      return value1.d;
    }

    localStorage.removeItem(key);

    return null;
  }

  static set(key: string, value: any, ttl: number = 0) {

    let obj:ICacheRecord = {
      v: ttl ? new Date().getTime() + ttl : 0,
      d: value
    };

    localStorage.setItem(key, this.encode(obj));

  }

  static remove(key: string) {
    localStorage.removeItem(key);
  }

  static removeAll() {
    localStorage.clear();
  }

  private static encode(value: ICacheRecord):string {
    return JSON.stringify(value);
  }

  private static decode(value: string):ICacheRecord {
    if (!value) {
      return null;
    }
    return JSON.parse(value);
  }

  private static isValid(value: ICacheRecord) {
    return !value.v || value.v > new Date().getTime();
  }

}

interface ICacheRecord {
  v: number;
  d: any;
}