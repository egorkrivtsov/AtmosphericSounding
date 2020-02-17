
export const clone = (obj: any) => {
  return obj
}

export const nameOfFunction = (_object: any, _function: Function): string => {
  var _functionName = null
  Object.getOwnPropertyNames(_object).forEach(prop => {
    if (_object[prop] === _function) {
      _functionName = prop
    }
  })

  if (_functionName !== null) {
    return _functionName
  }

  var proto = Object.getPrototypeOf(_object)
  if (proto) {
    return nameOfFunction(proto, _function)
  }
  return ''
}

export class ClassHelper {
  public static getMethodName (obj: any, method: any): any {
    var methodName = null
    Object.getOwnPropertyNames(obj).forEach(prop => {
      if (obj[prop] === method) {
        methodName = prop
      }
    })

    if (methodName !== null) {
      return methodName
    }

    var proto = Object.getPrototypeOf(obj)
    if (proto) {
      return ClassHelper.getMethodName(proto, method)
    }
    return null
  }
}
