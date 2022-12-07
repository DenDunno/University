export class JobInfo {
  number: number;
  priority: number;
  needsPoint: boolean;
  isFinished: boolean;
  points: PointInfo[];   
}

export class PointInfo {
    number: number;
    parentNumber: number;
    isFinished: boolean;
    hostInfo: Object;
}