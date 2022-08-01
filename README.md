# WinformOpenCV
在学习OpenCV的时候发现有C#版本的OpenCV库OpenCvSharp，其实也有其他C#版本OpenCV库，但是这个库的话封装的比较贴近C++版本的OpenCV，碰到不知道该怎么使用的方法，可以在网上看C++版本的教程然后用C#中实现。想快速学习学习OpenCV也可以使用Python版本，可以不用考虑环境各方面的问题。
## 遇到的坑
想把使用OpenCvSharp库的Web项目部署到Linux，发现会报一个[错误](https://github.com/shimat/opencvsharp/issues/983 "错误")，类似这种错误，找到了OpenCvSharp项目作者shimat给出的[解决方案](https://github.com/shimat/opencvsharp#ubuntu-1804-1 "解决方案")，参考Ubuntu系统按照的那一段内容，CentOS也一样的流程。
大致流程如下：
1. 在服务器下载OpenCV和OpenCV_Contrib项目编译安装，版本需要一致
2. 下载OpencvSharp编译安装，版本需要和上面一致
3. 配置环境变量

上面流程操作完.Net Core项目就能正常使用OpenCV了
