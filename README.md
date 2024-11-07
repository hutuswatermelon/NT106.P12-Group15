- Contributors: Cáp Hữu Tú, Huỳnh Ngọc Ngân Tuyền, Lê Hoàng Việt
- Mô tả đồ án cuối kỳ:
  + Tên đồ án: Story telling (Ứng dụng kể chuyện nối tiếp kết hợp chức năng giao tiếp trong thời gian thực thông qua mạng LAN)
  + Tổng quan: Người chơi sẽ đăng ký / đăng nhập và chọn phòng chơi. Mỗi phòng có tối đa 8 người chơi và tối thiểu 2 người để bắt đầu trò chơi. Mỗi người chơi đóng vai trò người kể chuyện, viết các câu để tạo thành câu chuyện. Số câu chuyện được kể ra tương ứng với số người chơi có trong phòng; số lượng câu trong mỗi câu chuyện sẽ được chủ phòng set từ trước. Câu đầu tiên mỗi người chơi viết ra được coi là câu mở đầu cho mỗi một câu chuyện, sau đó phần mở đầu được hoán đổi random cho những người trong phòng viết tiếp. Lưu ý, khi người chơi được random câu chuyện để viết tiếp, người chơi sẽ thấy được nội dung của câu trước nhưng không biết người kể là ai. Mỗi người chơi tiếp tục viết 1 câu. Như vậy, số lượng câu của các câu chuyện sẽ đồng thời tăng qua mỗi lần các người chơi viết. Trò chơi kết thúc khi số lượng câu trong mỗi câu chuyện đạt số lượng chủ phòng đã set ban đầu. Các câu chuyện được ghép từ các câu hoán đổi trước đó sẽ lần lượt hiện lên.
  + Chức năng:
    + Quản lý người dùng: Người dùng tham gia trò chơi bằng cách đăng kí (nếu chưa từng chơi) hoặc đăng nhập với tên mong muốn (sẽ lưu lại các câu chuyện từng kể).
    + Quản lý phòng:
        + Tham gia phòng: Hiển thị thông tin phòng hiện có (số lượng người hiện có, trạng thái bắt đầu,...). Khi người dùng chọn phòng, tiến hành kiểm tra xem phòng còn chỗ trống, thêm người dùng vào phòng. Người dùng vào phòng đầu tiên sẽ là host. Khi host hiện tại rời phòng, người vào phòng sau host sẽ trở thành host.
        + Quản lý câu chuyện:
            + Tạo câu chuyện mới: Khởi tạo một câu chuyện mới với câu đầu tiên.
            + Thêm câu vào câu chuyện: Kiểm tra xem người dùng có quyền thêm câu không, thêm câu vào câu chuyện.
            + Hiển thị câu chuyện: Lấy toàn bộ câu chuyện từ cơ sở dữ liệu và hiển thị lên giao diện.
            + Xem lại câu chuyện: Các câu chuyện đã kể sẽ được lưu trữ -> người dùng có thể xem lại
- Số lượng người tham gia: tối đa 8 người
- Mô hình client, server
- Dùng mạng LAN để kết nối người chơi
 
