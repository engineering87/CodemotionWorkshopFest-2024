/** @format */

(BigInt.prototype as any).toJSON = function () {
  return this.toString();
};

export function saveToSessionStorage(state: any) {
  try {
    const serializedState = JSON.stringify(state);
    sessionStorage.setItem('reduxState', serializedState);
  } catch (e) {
    console.log(e);
  }
}

export function loadFromSessionStorage() {
  try {
    const serializedState = sessionStorage.getItem('reduxState');
    if (serializedState) {
      return JSON.parse(serializedState);
    } else {
      return undefined;
    }
  } catch (e) {
    console.log(e);
    return undefined;
  }
}
