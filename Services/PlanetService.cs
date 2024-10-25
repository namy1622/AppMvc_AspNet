using App.Models;

namespace App.Services{
    public class PlanetService : List<PlanetModel>{
        public PlanetService(){
            Add(new PlanetModel(){
                Id = 1,
                Name = "Mercury",
                VnName = "Sao Thủy ",
                Content = "Thủy Tinh (chữ Hán: 水星) là hành tinh nhỏ nhất và gần Mặt Trời nhất trong tám hành tinh thuộc hệ Mặt Trời, với chu kỳ quỹ đạo bằng khoảng 88 ngày Trái Đất. Nhìn từ Trái Đất, hành tinh hiện lên với chu kỳ giao hội trên quỹ đạo bằng xấp xỉ 116 ngày, và nhanh hơn hẳn những hành tinh khác. Tốc độ chuyển động nhanh này đã khiến người La Mã đặt tên hành tinh là Mercurius, vị thần liên lạc và đưa tin một cách nhanh chóng. Trong thần thoại Hy Lạp tên của vị thần này là Hermes (Ερμής). Tên tiếng Việt của hành tinh này dựa theo tên do Trung Quốc đặt, chọn theo hành thủy trong ngũ hành."
            });

             Add(new PlanetModel(){
                Id = 2,
                Name = "Venus",
                VnName = "Sao Kim",
                Content = "là hành tinh thứ 2 trong Hệ Mặt Trời, tự quay quanh nó với chu kỳ khoảng 243 ngày Trái Đất.[10] Xếp sau Mặt Trăng, nó là thiên thể tự nhiên sáng nhất trong bầu trời tối, với cấp sao biểu kiến bằng −4.6, đủ sáng để tạo nên bóng trên mặt nước.[12] Bởi vì Sao Kim là hành tinh phía trong tính từ Trái Đất, nó không bao giờ xuất hiện trên bầu trời mà quá xa Mặt Trời: góc ly giác đạt cực đại bằng 47,8°. Sao Kim đạt độ sáng lớn nhất ngay sát thời điểm hoàng hôn hoặc bình minh, do vậy mà dân gian còn gọi là sao Hôm, khi hành tinh này hiện lên lúc hoàng hôn, và sao Mai, khi hành tinh này hiện lên lúc bình minh."
            });
             Add(new PlanetModel(){
                Id = 3,
                Name = "Earth",
                VnName = "Trái Đất",
                Content = "là hành tinh thứ ba tính từ Mặt Trời, đồng thời cũng là hành tinh lớn nhất trong các hành tinh đất đá của hệ Mặt Trời xét về bán kính, khối lượng và mật độ của vật chất. Trái Đất còn được biết tên với các tên gọi \"hành tinh xanh\",[note 2] là nhà của hàng triệu loài sinh vật,[13] trong đó có con người và cho đến nay nó là nơi duy nhất trong vũ trụ được biết đến là có sự sống"
            });
             Add(new PlanetModel(){
                Id = 4,
                Name = "Mars",
                VnName = "Sao Hỏa",
                Content = "là hành tinh thứ tư ở Hệ Mặt Trời và là hành tinh đất đá ở xa Mặt Trời nhất, với bán kính bé thứ hai so với các hành tinh khác. Sao Hoả có màu cam đỏ do bề mặt của hành tinh được bao phủ bởi lớp vụn sắt(III) oxit, do đó còn có tên gọi khác là \"hành tinh đỏ\".[16][17] Vì bán cầu Bắc của Sao Hoả có bồn trũng Bắc Cực chiếm đến 40% diện tích hành tinh, so bán cầu Nam thì bán cầu Bắc phẳng hơn và ít hố va chạm hơn. Khí quyển của Sao Hoả khá mỏng với thành phần chính là cacbon dioxit. Ở hai cực Sao Hoả là lớp băng được làm bằng nước. Sao Hoả có hai vệ tinh tự nhiên: Phobos và Deimos."


            });
             Add(new PlanetModel(){
                Id = 5,
                Name = "Jupiter",
                VnName = "Sao Mộc",
                Content = "là hành tinh thứ năm tính từ Mặt Trời và là hành tinh lớn nhất trong Hệ Mặt Trời.[12] Nó là hành tinh khí khổng lồ với khối lượng bằng một phần nghìn của Mặt Trời nhưng bằng hai lần rưỡi tổng khối lượng của tất cả các hành tinh khác trong Hệ Mặt Trời cộng lại."
            });
             Add(new PlanetModel(){
                Id = 6,
                Name = "Saturn",
                VnName = "Sao Thổ ",
                Content = "là hành tinh thứ sáu tính theo khoảng cách trung bình từ Mặt Trời và là hành tinh lớn thứ hai về đường kính cũng như khối lượng, sau Sao Mộc trong hệ Mặt Trời. Tên tiếng Anh của hành tinh mang tên thần Saturn trong thần thoại La Mã, ký hiệu thiên văn của hành tinh là (♄) thể hiện cái liềm của thần. Sao Thổ là hành tinh khí khổng lồ với bán kính trung bình bằng 9 lần của Trái Đất.[14][15] Tuy khối lượng của hành tinh cao gấp 95 lần khối lượng của Trái Đất nhưng với thể tích lớn hơn 763 lần, khối lượng riêng trung bình của Sao Thổ chỉ bằng một phần tám so với của Trái Đất.[16][17][18]"
            });
             Add(new PlanetModel(){
                Id = 7,
                Name = "Uranus",
                VnName = "Sao Thiên Vương ",
                Content = "là hành tinh thứ bảy tính từ Mặt Trời, là hành tinh có bán kính lớn thứ ba và có khối lượng lớn thứ tư trong Hệ Mặt Trời. Sao Thiên Vương có thành phần tương tự như Sao Hải Vương. Cả hai có thành phần hóa học khác so với hai hành tinh khí khổng lồ lớn hơn là Sao Mộc và Sao Thổ. Vì vậy, các nhà thiên văn thỉnh thoảng đưa các hành tinh này vào danh sách \"hành tinh băng khổng lồ\". Khí quyển của Sao Thiên Vương tương tự như của Sao Mộc và Sao Thổ về thành phần cơ bản như hiđrô và heli. Khác là chúng chứa nhiều hợp chất dễ bay hơi như nước, amonia và methan cùng với lượng nhỏ"
            });
             Add(new PlanetModel(){
                Id = 8,
                Name = "Neptune",
                VnName = "Sao Hải Vương",
                Content = "là hành tinh thứ tám và xa nhất tính từ Mặt Trời trong Hệ Mặt Trời. Nó là hành tinh lớn thứ tư về đường kính và lớn thứ ba về khối lượng. Sao Hải Vương có khối lượng riêng lớn nhất trong số các hành tinh khí trong hệ Mặt trời. Sao Hải Vương có khối lượng gấp 17 lần khối lượng của Trái Đất và hơi lớn hơn khối lượng của Sao Thiên Vương (xấp xỉ bằng 15 lần của Trái Đất).[11] Sao Hải Vương quay trên quỹ đạo quanh Mặt Trời ở khoảng cách trung bình 30,1 AU, bằng khoảng 30 lần khoảng cách Trái Đất - Mặt Trời. Sao Hải Vương được đặt tên theo vị thần biển cả của người La Mã (Neptune). Nó có ký hiệu thiên văn là ♆, là biểu tượng cách điệu cây đinh ba của thần Neptune hoặc chữ cái psi của Hy Lạp."
            });
        }
    }
}