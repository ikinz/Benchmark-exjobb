
import java.util.ArrayList;
import java.util.List;
import javafx.application.Application;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.scene.Scene;
import javafx.scene.control.ListCell;
import javafx.scene.control.ListView;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;
import javafx.util.Callback;

import java.io.IOException;
import java.nio.charset.Charset;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

/**
 * @web http://java-buddy.blogspot.com/
 */
public class JavaFX_ListView extends Application {
    List<String> myList;

    //Create dummy list of MyObject
    private void prepareMyList(){
        try {
          //for (String str : ReadAll.readAllLines())
          //  myList.add(str);
          myList = ReadAll.readAllLines();
        } catch (IOException e) {

        }
    }

    @Override
    public void start(Stage primaryStage) {

        primaryStage.setTitle("TestGrafList");

        prepareMyList();
        ListView<String> listView = new ListView<String>();
        ObservableList<String> myObservableList = FXCollections.observableList(myList);
        listView.setItems(myObservableList);

        listView.setCellFactory(new Callback<ListView<String>, ListCell<String>>(){

            @Override
            public ListCell<String> call(ListView<String> p) {

                ListCell<String> cell = new ListCell<String>(){

                    @Override
                    protected void updateItem(String t, boolean bln) {
                        super.updateItem(t, bln);
                        if (t != null) {
                            setText(t);
                        }
                    }

                };

                return cell;
            }
        });


        StackPane root = new StackPane();
        root.getChildren().add(listView);
        primaryStage.setScene(new Scene(root, 300, 200));
        primaryStage.show();
    }

    public static void main(String[] args) {
        launch(args);
    }

    private static class ReadAll {
      public static List<String> readAllLines() throws IOException {
        String filename = "../DumpFile/dump.txt";
        Path file = Paths.get(filename);
        ArrayList<String> arrList = new ArrayList<String>();
        for (String s : Files.readAllLines(file, Charset.defaultCharset()))
          arrList.add(s);

	return arrList;
        }
      }
}
