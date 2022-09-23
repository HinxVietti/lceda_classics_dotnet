# 立创EDA 文档格式说明 C#

## 意图

- 用于解释立创工程
- 用于用C#代码生成或者布局简易的PCB



## 功能

- PCB 工程解释
- C#对应对象类型



## TODO

- 完成原理图部分

  

  

  

## 实例

#### 源代码

```json
{
  "head": {
    "docType": "3",
   ....
    "hasIdFlag": true
  },
  "canvas": "CA~1000~1000~#000000~yes~#FFFFFF~10~1000~1000~line~0.5~mm~1~45~~0.5~4020~3728.5~0~yes",
  "shape": [
    "TRACK~1~10~~4020 3689.13 4059.37 3689.13 4059.37 3728.5 4020 3728.5 4020 3689.13~gge7~0",
    "TRACK~1~1~VCC~4042.949 3......
  ],
  "layers": [
    "1~TopLayer~#FF0000~true~true~true~",
    "2~BottomLayer~#0000FF~true~false~true~",
    "7~TopSolderMaskLayer~#800080~true~false~true~0.3",
      ....
```

#### PCB 解释

```json
{
    "head": {
        "docType": "3",
        "editorVersion": "6.5.15",
        ....
        "hasIdFlag": true
    },
    "canvas": {
        "viewWidth": "1000",
        "viewHeight": "1000",
        "backGround": "#000000",
        "gridVisible": "yes",
        ....
        "routeConflict": "0",
        "removeLoop": "yes",
        "固定标识": "CA"
    },
    "shape": [
        {
            "strokeWidth": "1",
            "layerid": "10",
            "net": "",
            "pointArr": "4020 3689.13 4059.37 3689.13 4059.37 3728.5 4020 3728.5 4020 3689.13",
            "gId": "gge7",
            "locked": "0",
            "cmdKey": "TRACK"
        },
        {
            "strokeWidth": "1",
            "layerid": "1",
            "net": "VCC",
            "pointArr": "4042.949 3702.701 4042.949 3698.551 4046 3695.5 4052.5 3695.5 4053 3696",
            "gId": "gge2077",
            "locked": "0",
            "cmdKey": "TRACK"
        },
        {
            "strokeWidth": "1",
            "layerid": "1",
            "net": "GND",
            "pointArr": "4024.051 3715.299 4024.051 3721.551 4027 3724.5 4048 3724.5 4053 3719.5",
            "gId": "gge2085",
            "locked": "0",
            "cmdKey": "TRACK"
        },
        {
            "strokeWidth": "1",
            "layerid": "1",
            "net": "DAT",
            "pointArr": "4042.949 3715.299 4045.701 3715.299 4053 3708",
            "gId": "gge2081",
            "locked": "0",
            "cmdKey": "TRACK"
            ....
```

