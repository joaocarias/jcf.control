export interface ApiResponse<T> {
    isSuccess: boolean
    result: T
    statusCode: number
    errorMessages: string[]
  }