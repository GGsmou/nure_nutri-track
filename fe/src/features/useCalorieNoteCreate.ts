import { useMutation } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { CalorieNote } from "../types/CalorieNote";

export const useCalorieNoteCreate = (
  filter:
    | {
        type: "edit";
        data: { id: string };
      }
    | {
        type: "create";
      },
) => {
  return useMutation((data: CalorieNote) => {
    if (filter.type === "edit") {
      return fetchAbstract("CalorieNotes/" + filter.data.id, "PUT", data);
    }

    return fetchAbstract("CalorieNotes/", "POST", data);
  });
};
