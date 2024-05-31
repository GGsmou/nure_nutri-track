import { useQuery } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";
import { Recepie } from "../types/Recepie";
import { urlBuilder } from "../utils/urlBuilder";
import { INGREDIENTS } from "../utils/ingredients";

export const useRecepieGetAllQuery = (filter: { id?: string }) => {
  return useQuery({
    queryKey: ["recepies", filter],
    queryFn: async () => {
      const res = await fetchAbstract(
        urlBuilder("Recipes", filter, true),
        "GET",
      );

      const ress = Array.isArray(res) ? res : [res];

      return ress.map((obj: Record<string, unknown>) => ({
        ...obj,
        // eslint-disable-next-line @typescript-eslint/no-unsafe-assignment, @typescript-eslint/no-explicit-any
        ingredients: (obj.ingredients as Record<any, any>).map(
          // eslint-disable-next-line @typescript-eslint/no-unsafe-assignment, @typescript-eslint/no-explicit-any
          (x: any) => INGREDIENTS.find((i) => i.id === x.id)?.name || "",
        ),
        votes: obj.reviews,
      })) as unknown as Recepie[];
    },
  });
};
